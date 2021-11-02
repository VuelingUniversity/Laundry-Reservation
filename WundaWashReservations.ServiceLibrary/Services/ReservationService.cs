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

        public bool CreateReservation(CreateReservationRequest createRequest)
        {
            try
            {
                Reservation reservation = new Reservation
                {
                    Id = GenerateReservationId(),
                    ReservationDate = createRequest.ReservationDate,
                    MachineId = ChooseWashMachine(),
                    Pin = GeneratePin(),
                    PhoneNumber = createRequest.PhoneNumber,
                    Email = createRequest.Email,
                    Status = StatusEnum.Pending
                };
                MachineLockRequest lockRequest = new MachineLockRequest
                {
                    ReservationId = reservation.Id,
                    MachineNumber = reservation.MachineId,
                    ReservationDate = reservation.ReservationDate,
                    Pin = reservation.Pin
                };
                var repositorySaveInDBResponse = _reservationRepository.SaveReservation(reservation);
                _emailRepository.SendConfirmationEmail(reservation.Email, reservation.MachineId, reservation.Pin);
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
            if (!repositorySaveInDBResponse)
            {
                _machineApiRepository.UnlockMachine(reservationId);
            }
            if (!machineLockReponse)
            {
                _reservationRepository.DeleteReservation(reservationId);
            }
        }

        public bool ClaimReservation(ClaimReservationRequest claimRequest)
        {
            try
            {
                var reservationId = _reservationRepository.GetReservationIdByPin(claimRequest.MachineId, claimRequest.Pin);
                var status = _reservationRepository.GetReservationStatus(reservationId);

                if (!String.IsNullOrEmpty(reservationId) && (status != StatusEnum.Used | status != StatusEnum.Cancelled))
                {
                    var updateResponse = _reservationRepository.UpdateReservationStatus(reservationId, StatusEnum.Used);
                    var unlockResponse = _machineApiRepository.UnlockMachine(reservationId);

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
                var email = _reservationRepository.GetEmail(reservationId);
                _emailRepository.SendCancelReservationEmail(email, reservationId);
                var updateResponse = _reservationRepository.UpdateReservationStatus(reservationId, StatusEnum.Cancelled);
                var unlockResponse = _machineApiRepository.UnlockMachine(reservationId);
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