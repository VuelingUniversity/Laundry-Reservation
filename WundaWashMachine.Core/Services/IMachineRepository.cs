using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashMachine.Core.Models;

namespace WundaWashMachine.Core.Services
{
    public interface IMachineRepository
    {
        void SaveLock(LockRequest lockRequest);

        void UpdateLockInfo(string reservationId, DateTime reservationDate, int pin);

        bool IsMachineUnlocked(int id);

        bool ExistReservationId(string reservationId);

        void SaveUnlock(string reservationId);
    }
}