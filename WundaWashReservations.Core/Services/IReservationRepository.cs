using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashReservations.Core.Models;

namespace WundaWashReservations.Core.Services
{
    public interface IReservationRepository
    {
        bool SaveReservation(Reservation reservation);

        bool ClaimReservation(int machineId, int pin);

        bool CancelReservation(int id);
    }
}