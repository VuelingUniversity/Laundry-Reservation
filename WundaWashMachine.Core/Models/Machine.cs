using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashMachine.Core.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public bool Unlocked { get; set; }
        public string ReservationId { get; set; }
        public DateTime? ReservationDate { get; set; }
        public int? Pin { get; set; }
    }
}