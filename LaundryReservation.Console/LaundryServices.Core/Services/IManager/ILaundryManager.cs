using LaundryServices.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryServices.Core.Services.IManager
{
    public interface ILaundryManager
    {
        bool CreateReservation(Reservation reservation);

        bool DeleteReservation(int id);

        List<Reservation> GetReservations();
    }
}
