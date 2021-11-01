using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWash.Core.Models
{
    public class Reservation
    {
        public int Id_reservation { get; set; }
        public int Id_patron { get; set; }
        public int Id_machine { get; set; }
        public int Pin { get; set; }
        public DateTime DateReservation { get; set; }
    }
}
