using KataMachineAPI.Core.Models;
using System.Collections.Generic;

namespace KataMachineAPI.Core.Services
{
    public interface IReservationRepository
    {
        bool CreateReservation(Reservation reservation);

        bool DeleteReservation(int id);

        List<Reservation> GetAll();

        Reservation GetReservationById(int id);

        bool UpdateReservation(int TargetId, Reservation reservation);
    }
}