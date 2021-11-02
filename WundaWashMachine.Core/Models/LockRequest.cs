using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashMachine.Core.Models
{
    public class LockRequest
    {
        public int MachineNumber { get; set; }
        public string ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int Pin { get; set; }
    }
}