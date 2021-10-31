using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashMachine.ServiceLibrary.Interfaces;

namespace WundaWashMachine.ServiceLibrary.Services
{
    public class MachineService : IMachineService
    {
        public bool Lock(int machineNumber, string reservationId, DateTime reservationDate, int pin)
        {
            throw new NotImplementedException();
        }

        public bool Unlock(string reservationId)
        {
            try
            {
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}