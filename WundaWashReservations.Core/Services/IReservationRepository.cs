using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashReservations.Core.Services
{
    public interface IReservationRepository
    {
        bool CreateReservation(DateTime reservationDate, int phoneNumber, string email);

        bool ClaimReservation(int machineId, int pin);

        bool CancelReservation(int id);
    }
}