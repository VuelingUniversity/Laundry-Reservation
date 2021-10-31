using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashReservations.Core.Models
{
    public class Reservation
    {
        public string Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public int MachineId { get; set; }
        public int Pin { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}