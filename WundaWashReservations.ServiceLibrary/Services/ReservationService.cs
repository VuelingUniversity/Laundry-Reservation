using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashReservations.Core.Enums;
using WundaWashReservations.Core.Models;
using WundaWashReservations.Core.Services;
using WundaWashReservations.Email.ServiceLibrary.Interfaces;
using WundaWashReservations.ServiceLibrary.Interfaces;
using WundaWashReservations.Sms.ServiceLibrary.Interfaces;

namespace WundaWashReservations.ServiceLibrary.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;
        private readonly IReservationRepository _reservationRepository;
        private readonly IMachineApiRepository _machineApiRepository;

        public ReservationService(IEmailService emailService, ISmsService smsService, IReservationRepository reservationRepository, IMachineApiRepository machineApiRepository)
        {
            _emailService = emailService;
            _smsService = smsService;
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

                var repositorySaveInDBResponse = _reservationRepository.SaveReservation(reservation);
                _emailService.SendConfirmationEmail(email, reservation.MachineId, reservation.Pin);
                var machineLockReponse = _machineApiRepository.LockMachine(reservation.Id, reservation.MachineId, reservationDate, reservation.Pin);
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
                _machineApiRepository.UnlockMachine(reservationId, machineId);
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

                if (!String.IsNullOrEmpty(reservationId) && (status != StatusEnum.Used | status != StatusEnum.Cancelled))
                {
                    var updateResponse = _reservationRepository.UpdateReservationStatus(reservationId, StatusEnum.Used);
                    var unlockResponse = _machineApiRepository.UnlockMachine(reservationId, machineNumber);
                    // ver que hago si una de las dos cosas no pasa
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
                var email = _reservationRepository.GetEmail(reservationId);
                _emailService.SendCancelReservationEmail(email, reservationId);
                var updateResponse = _reservationRepository.UpdateReservationStatus(reservationId, StatusEnum.Cancelled); var machineNumber = _reservationRepository.GetMachineId(reservationId);
                var unlockResponse = _machineApiRepository.UnlockMachine(reservationId, machineNumber);
                return updateResponse && unlockResponse;
            }
            catch (Exception exception)
            {
                // log
                throw;
            }
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

        public void DeleteReservation(string reservationId)
        {
            _reservationRepository.DeleteReservation(reservationId);
        }
    }
}