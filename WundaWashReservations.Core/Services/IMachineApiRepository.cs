using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashReservations.Core.Services
{
    public interface IMachineApiRepository
    {
        bool LockMachine(string reservationId, int machineNumber, DateTime reservationDate, int pin);

        bool UnlockMachine(string reservationId, int machineNumber);
    }
}