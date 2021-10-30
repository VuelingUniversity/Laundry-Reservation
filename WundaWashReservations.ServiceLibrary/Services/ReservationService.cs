using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
        }

        public bool ClaimReservation(int machineId, int pin)
        {
            throw new NotImplementedException();
        }

        public bool CancelReservation(int id)
        {
            throw new NotImplementedException();
        }
    }
}