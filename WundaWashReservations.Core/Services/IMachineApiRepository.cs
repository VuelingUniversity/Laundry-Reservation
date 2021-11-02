using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashReservations.Core.Models;

namespace WundaWashReservations.Core.Services
{
    public interface IMachineApiRepository
    {
        bool LockMachine(MachineLockRequest lockRequest);

        bool UnlockMachine(MachineUnlockRequest unlockRequest);
    }
}