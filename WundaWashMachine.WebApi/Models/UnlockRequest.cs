using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WundaWashMachine.WebApi.Models
{
    public class UnlockRequest
    {
        public int MachineNumber { get; set; }
        public string ReservationId { get; set; }
    }
}