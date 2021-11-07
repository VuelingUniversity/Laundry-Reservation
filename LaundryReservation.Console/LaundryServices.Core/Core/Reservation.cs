using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryServices.Core.Core
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime? ReservationDate { get; set; }
        public string Pin { get; set; }
        public bool Active { get; set; }
        public int? IdMachine { get; set; }
        public Machine Machine { get; set; }      
    }
}
