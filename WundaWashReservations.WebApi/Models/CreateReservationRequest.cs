using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WundaWashReservations.WebApi.Models
{
    public class CreateReservationRequest
    {
        public DateTime ReservationDate { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}