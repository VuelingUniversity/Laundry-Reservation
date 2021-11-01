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

        public MachineRepository(WundaWashMachineContext context)
        {
            _context = context;
            _machines = context.Set<Machine>();
        }

        public void SaveLock(int machineNumber, string reservationId, DateTime reservationDate, int pin)
        {
            try
            {
                var machine = _machines.FirstOrDefault(item => item.Id == machineNumber);
                machine.Unlocked = false;
                machine.ReservationId = reservationId;
                machine.ReservationDate = reservationDate;
                machine.Pin = pin;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateLockInfo(string reservationId, DateTime reservationDate, int pin)
        {
            try
            {
                var machine = _machines.FirstOrDefault(item => item.ReservationId == reservationId);
                machine.ReservationDate = reservationDate;
                machine.Pin = pin;
                _context.SaveChanges();
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

        public bool ExistReservationId(string reservationId)
        {
            try
            {
                var machine = _machines.FirstOrDefault(item => item.ReservationId == reservationId);
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
                var machine = _machines.FirstOrDefault(item => item.ReservationId == reservationId);
                machine.Unlocked = true;
                machine.Pin = null;
                machine.ReservationId = null;
                machine.ReservationDate = null;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}