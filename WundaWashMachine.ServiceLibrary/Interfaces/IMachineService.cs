using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashMachine.ServiceLibrary.Interfaces
{
    public interface IMachineService
    {
        bool Lock(int machineNumber, string reservationId, DateTime reservationDate, int pin);

        bool Unlock(string reservationId);
    }
}