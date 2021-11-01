using KataMachineAPI.Core.Models;
using System;
using System.Collections.Generic;

namespace KataMachineAPI.ServiceLibrary.Manager
{
    public interface ILaundryManager
    {
        bool CreateReservation(Reservation reservation);
        bool DeleteReservation(int id);
        List<Reservation> GetReservations();
        bool Lock(string reservationId, DateTime reservationDateTime, int pin);
        void Unlock(string reservationId);
    }
}