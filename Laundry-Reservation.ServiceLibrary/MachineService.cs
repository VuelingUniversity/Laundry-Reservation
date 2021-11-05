using Laundry_Reservation.Domain.Models;
using Laundry_Reservation.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laundry_Reservation.ServiceLibrary
{
    public class MachineService : IMachineService
    {
        private readonly IMachineRepository _repository;

        public MachineService(IMachineRepository repository)
        {
            _repository = repository;
        }

        public Machine GetMachineById(int id)
        {
            return _repository.GetMachineById(id);
        }

        public IEnumerable<Machine> GetMachines()
        {
            return _repository.GetMachines();
        }
    }
}