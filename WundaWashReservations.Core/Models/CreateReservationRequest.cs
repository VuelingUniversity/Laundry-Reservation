using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashReservations.Core.Models
{
    public class CreateReservationRequest
    {
        public DateTime ReservationDate { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}