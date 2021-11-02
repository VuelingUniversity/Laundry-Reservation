using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashReservations.Core.Models
{
    public class ClaimReservationRequest
    {
        public int MachineId { get; set; }
        public int Pin { get; set; }
    }
}