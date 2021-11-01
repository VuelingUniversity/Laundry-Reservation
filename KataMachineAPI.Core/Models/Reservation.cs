using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataMachineAPI.Core.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public string EmailAdress { get; set; }
        public int MachineNumber { get; set; }
        public int PIN { get; set; }
    }
}