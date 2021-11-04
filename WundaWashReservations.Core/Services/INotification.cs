using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashReservations.Core.Services
{
    public interface INotification
    {
        void SendConfirmationNotification(string email, string reservationId, int machineId, int pin);

        void SendCancelReservationNotification(string email, string reservationId);
    }
}