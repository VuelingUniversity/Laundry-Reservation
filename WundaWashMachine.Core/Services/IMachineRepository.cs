using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashMachine.Core.Services
{
    public interface IMachineRepository
    {
        void SaveLock(int machineNumber, string reservationId, DateTime reservationDate, int pin);

        void UpdateLockInfo(string reservationId, DateTime reservationDate, int pin);

        bool IsMachineUnlocked(int id);

        bool ExistReservationId(int machineId, string reservationId);

        void SaveUnlock(string reservationId);
    }
}