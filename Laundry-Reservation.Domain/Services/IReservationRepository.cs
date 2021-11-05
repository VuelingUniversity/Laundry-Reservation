using Laundry_Reservation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laundry_Reservation.Domain.Services
{
    public interface IReservationRepository
    {
        Reservation GetReservation(int id);

        IEnumerable<Reservation> GetReservations();
    }
}