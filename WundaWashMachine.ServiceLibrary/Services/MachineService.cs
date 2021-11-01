using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashMachine.Core.Services;
using WundaWashMachine.ServiceLibrary.Interfaces;

namespace WundaWashMachine.ServiceLibrary.Services
{
    public class MachineService : IMachineService
    {
        private readonly IMachineRepository _machineRepository;

        public MachineService(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }

        public bool Lock(int machineNumber, string reservationId, DateTime reservationDate, int pin)
        {
            try
            {
                if (_machineRepository.IsMachineUnlocked(machineNumber))
                {
                    _machineRepository.SaveLock(machineNumber, reservationId, reservationDate, pin);
                    return true;
                }
                if (_machineRepository.ExistReservationId(machineNumber, reservationId))
                {
                    _machineRepository.UpdateLockInfo(reservationId, reservationDate, pin);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Unlock(string reservationId)
        {
            try
            {
                _machineRepository.SaveUnlock(reservationId);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}