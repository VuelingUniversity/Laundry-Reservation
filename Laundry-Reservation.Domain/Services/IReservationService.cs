using Laundry_Reservation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laundry_Reservation.Domain.Services
{
    public interface IReservationService
    {
        Reservation GetReservation(int id);

        IEnumerable<Reservation> GetReservations();
    }
}