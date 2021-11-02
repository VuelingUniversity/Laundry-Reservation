using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashMachine.Core.Models;

namespace WundaWashMachine.ServiceLibrary.Interfaces
{
    public interface IMachineService
    {
        bool Lock(LockRequest lockRequest);

        bool Unlock(string reservationId);
    }
}