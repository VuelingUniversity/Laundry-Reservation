using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashMachine.Core.Models;
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

        public bool Lock(LockRequest lockRequest)
        {
            try
            {
                if (_machineRepository.IsMachineUnlocked(lockRequest.MachineNumber))
                {
                    _machineRepository.SaveLock(lockRequest);
                    return true;
                }
                if (_machineRepository.ExistReservationId(lockRequest.ReservationId))
                {
                    _machineRepository.UpdateLockInfo(lockRequest.ReservationId, lockRequest.ReservationDate, lockRequest.Pin);
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
                if (_machineRepository.ExistReservationId(reservationId))
                {
                    _machineRepository.SaveUnlock(reservationId);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}