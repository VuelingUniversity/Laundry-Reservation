using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashMachine.Core.Services;
using WundaWashMachine.EF.Infra.Context;
using WundaWashMachine.EF.Infra.DTO;

namespace WundaWashMachine.EF.Infra.Repositories
{
    public class MachineRepository : IMachineRepository
    {
        private readonly WundaWashMachineContext _context;
        private readonly DbSet<Machine> _machines;

        public MachineRepository(WundaWashMachineContext context, DbSet<Machine> machines)
        {
            _context = context;
            _machines = machines;
        }

        public void SaveLockInfo(int machineNumber, string reservationId, DateTime reservationDate, int pin)
        {
            try
            {
                var machine = _machines
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateMachineInfo(string reservationId, DateTime reservationDate, int pin)
        {
            try
            {
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsMachineUnlocked(int id)
        {
            try
            {
                var machine = _machines.FirstOrDefault(item => item.Id == id);
                return machine.Unlocked;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ExistReservationId(int machineId, string reservationId)
        {
            try
            {
                var machine = _machines.FirstOrDefault(item => item.Id == machineId);
                return machine.ReservationId.Equals(reservationId) ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveUnlock(string reservationId)
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