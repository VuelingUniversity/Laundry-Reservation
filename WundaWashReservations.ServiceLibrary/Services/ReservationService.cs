using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashReservations.Core.Enums;
using WundaWashReservations.Core.Models;
using WundaWashReservations.Core.Services;
using WundaWashReservations.ServiceLibrary.Interfaces;

namespace WundaWashReservations.ServiceLibrary.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IMachineApiRepository _machineApiRepository;

        public ReservationService(IEmailRepository emailRepository, IReservationRepository reservationRepository, IMachineApiRepository machineApiRepository)
        {
            _emailRepository = emailRepository;
            _reservationRepository = reservationRepository;
            _machineApiRepository = machineApiRepository;
        }

        public bool CreateReservation(DateTime reservationDate, int phoneNumber, string email)
        {
            try
            {
                Reservation reservation = new Reservation
                {
                    Id = GenerateReservationId(),
                    ReservationDate = reservationDate,
                    MachineId = ChooseWashMachine(),
                    Pin = GeneratePin(),
                    PhoneNumber = phoneNumber,
                    Email = email,
                    Status = StatusEnum.Pending
                };
                MachineLockRequest lockRequest = new MachineLockRequest
                {
                    ReservationId = reservation.Id,
                    MachineNumber = reservation.MachineId,
                    ReservationDate = reservationDate,
                    Pin = reservation.Pin
                };
                var repositorySaveInDBResponse = _reservationRepository.SaveReservation(reservation);
                _emailRepository.SendConfirmationEmail(email, reservation.MachineId, reservation.Pin);
                var machineLockReponse = _machineApiRepository.LockMachine(lockRequest);
                RevertCreateReservation(repositorySaveInDBResponse, machineLockReponse, reservation.Id, reservation.MachineId);
                return repositorySaveInDBResponse && machineLockReponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RevertCreateReservation(bool repositorySaveInDBResponse, bool machineLockReponse, string reservationId, int machineId)
        {
            MachineUnlockRequest unlockRequest = new MachineUnlockRequest
            {
                ReservationId = reservationId,
                MachineNumber = machineId
            };
            if (!repositorySaveInDBResponse)
            {
                _machineApiRepository.UnlockMachine(unlockRequest);
            }
            if (!machineLockReponse)
            {
                _reservationRepository.DeleteReservation(reservationId);
            }
        }

        public bool ClaimReservation(int machineNumber, int pin)
        {
            try
            {
                var reservationId = _reservationRepository.GetReservationIdByPin(machineNumber, pin);
                var status = _reservationRepository.GetReservationStatus(reservationId);
                MachineUnlockRequest unlockRequest = new MachineUnlockRequest
                {
                    ReservationId = reservationId,
                    MachineNumber = machineNumber
                };

                if (!String.IsNullOrEmpty(reservationId) && (status != StatusEnum.Used | status != StatusEnum.Cancelled))
                {
                    var updateResponse = _reservationRepository.UpdateReservationStatus(reservationId, StatusEnum.Used);
                    var unlockResponse = _machineApiRepository.UnlockMachine(unlockRequest);

                    return updateResponse && unlockResponse;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CancelReservation(string reservationId)
        {
            try
            {
                var machineNumber = _reservationRepository.GetMachineId(reservationId);
                MachineUnlockRequest unlockRequest = new MachineUnlockRequest
                {
                    ReservationId = reservationId,
                    MachineNumber = machineNumber
                };
                var email = _reservationRepository.GetEmail(reservationId);
                _emailRepository.SendCancelReservationEmail(email, reservationId);
                var updateResponse = _reservationRepository.UpdateReservationStatus(reservationId, StatusEnum.Cancelled);
                var unlockResponse = _machineApiRepository.UnlockMachine(unlockRequest);
                return updateResponse && unlockResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteReservation(string reservationId)
        {
            _reservationRepository.DeleteReservation(reservationId);
        }

        public string GenerateReservationId()
        {
            return Guid.NewGuid().ToString();
        }

        public int ChooseWashMachine()
        {
            Random random = new Random();
            return random.Next(1, 26);
        }

        public int GeneratePin()
        {
            return new Random().Next(10000, 99999);
        }
    }
}