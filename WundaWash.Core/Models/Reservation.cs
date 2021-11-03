using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWash.Core.Models
{
    public class Reservation
    {
        public int IdReservation { get; set; }
        public int IdPatron { get; set; }
        public int IdMachine { get; set; }
        public int Pin { get; set; }
        public DateTime DateReservation { get; set; }
    }
}
