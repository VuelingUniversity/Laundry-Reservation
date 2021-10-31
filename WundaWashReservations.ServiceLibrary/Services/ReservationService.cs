using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    Email = email
                };

                var repositorySaveInDBResponse = _reservationRepository.SaveReservation(reservation);
                _emailService.SendConfirmationEmail(email, reservation.MachineId, reservation.Pin);
                var machineLockReponse = _machineApiRepository.LockMachine(reservation.Id, reservation.MachineId, reservationDate, reservation.Pin);
                return repositorySaveInDBResponse && machineLockReponse;
                // control de si no se guarda en db o no hace lock la machine api.
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ClaimReservation(int machineId, int pin)
        {
            throw new NotImplementedException();
        }

        public bool CancelReservation(int id)
        {
            throw new NotImplementedException();
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