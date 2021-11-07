using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryServices.Core.Core
{
    public class Machine
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
