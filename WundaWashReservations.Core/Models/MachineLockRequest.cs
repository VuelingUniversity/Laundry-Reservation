using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashReservations.Core.Models
{
    public class MachineLockRequest
    {
        public string ReservationId { get; set; }
        public int MachineNumber { get; set; }
        public DateTime ReservationDate { get; set; }
        public int Pin { get; set; }
    }
}