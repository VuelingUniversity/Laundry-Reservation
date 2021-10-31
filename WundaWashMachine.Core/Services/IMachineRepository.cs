using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashMachine.Core.Services
{
    public interface IMachineRepository
    {
        void SaveLockInfo(int machineNumber, string reservationId, DateTime reservationDate, int pin);

        void UpdateMachineInfo(string reservationId, DateTime reservationDate, int pin);

        bool IsMachineUnlocked(int id);

        bool ExistReservationId(int machineId, string reservationId);

        void SaveUnlock(string reservationId);
    }
}