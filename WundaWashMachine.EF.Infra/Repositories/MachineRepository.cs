using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashMachine.Core.Services;

namespace WundaWashMachine.EF.Infra.Repositories
{
    public class MachineRepository : IMachineRepository
    {
        public bool SaveLockInfo()
        {
        }

        public bool IsMachineUnlocked()
        {
        }

        public bool SaveUnlock()
        {
            try
            {
                // cambiar estado lock borrar pin reservationId y dateTime
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}