using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WundaWashReservations.WebApi.Models
{
    public class ClaimReservationRequest
    {
        public int MachineId { get; set; }
        public int Pin { get; set; }
    }
}