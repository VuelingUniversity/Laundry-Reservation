using LaundryServices.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryServices.Core.Services.IRepository
{
    public interface IReservationRepository
    {
        List<Reservation> GetAll();
        Reservation GetReservationById(int id);
        bool CreateReservation(Reservation reservation);
        bool CancelReservation(int id);
       
    }
}
