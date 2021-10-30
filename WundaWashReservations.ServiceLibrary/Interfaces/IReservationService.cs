using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashReservations.ServiceLibrary.Interfaces
{
    public interface IReservationService
    {
        bool CreateReservation(DateTime reservationDate, int phoneNumber, string email);

        bool ClaimReservation(int machineId, int pin);

        bool CancelReservation(int id);
    }
}