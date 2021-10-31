using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashReservations.MachineApi.Infra.Models
{
    public class MachineApiUnlockRequest
    {
        public string ReservationId { get; set; }
        public int MachineNumber { get; set; }
    }
}