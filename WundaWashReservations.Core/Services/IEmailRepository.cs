using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashReservations.Core.Services
{
    public interface IEmailRepository
    {
        void SendConfirmationEmail(string email, string reservationId, int machineId, int pin);

        void SendCancelReservationEmail(string email, string reservationId);
    }
}