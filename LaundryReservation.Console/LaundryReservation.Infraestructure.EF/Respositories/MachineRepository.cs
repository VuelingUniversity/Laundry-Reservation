using LaundryReservation.Infraestructure.EF.Context;
using LaundryServices.Core.Core;
using LaundryServices.Core.Services.IRepository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryReservation.Infraestructure.EF.Respositories
{
    public class MachineRepository : IMachineRepository
    {
        private readonly LaundryReservationServiceContext _context;
        private readonly DbSet<Machine> _machines;
        public MachineRepository(LaundryReservationServiceContext context)
        {
            _context = context;
            _machines = context.Set<Machine>();
        }
        public List<Machine> GetAllEnableMachine()
        {
            try
            {
                var enableMachines = _machines.Where(x => x.Active == true).ToList();
                return enableMachines;
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Communication error with the database in GetAllEnableMachine");
                throw;
            }
        }
        public bool IsEnable(int id)
        {
            try
            {
                var machine = _machines.FirstOrDefault(x => x.Id == id);              
                 return machine.Active;
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Communication error with the database in IsEnable");
                throw;
            }
        }
        public void UpdateMachineEnable(int id, bool active)
        {
            try
            {
                var machine = _machines.FirstOrDefault(x => x.Id == id);
                machine.Active = active;
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Communication error with the database in UpdateMachineEnable");
                throw;
            }
        }
    }
}
