using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashMachine.Core.Models;
using WundaWashMachine.Core.Services;
using WundaWashMachine.EF.Infra.Context;
using WundaWashMachine.EF.Infra.DTO;
using Machine = WundaWashMachine.EF.Infra.DTO.Machine;

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

        public void SaveLock(LockRequest lockRequest)
        {
            try
            {
                var machine = _machines.FirstOrDefault(item => item.Id == lockRequest.MachineNumber);
                machine.Unlocked = false;
                machine.ReservationId = lockRequest.ReservationId;
                machine.ReservationDate = lockRequest.ReservationDate;
                machine.Pin = lockRequest.Pin;
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Communication error with the database in SaveLock");
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
            catch (Exception exception)
            {
                Log.Error(exception, "Communication error with the database in UpdateLockInfo");
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
            catch (Exception exception)
            {
                Log.Error(exception, "Communication error with the database in IsMachineUnlocked");
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
            catch (Exception exception)
            {
                Log.Error(exception, "Communication error with the database in ExistReservationId");
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
            catch (Exception exception)
            {
                Log.Error(exception, "Communication error with the database in SaveUnlock");
                throw;
            }
        }
    }
}