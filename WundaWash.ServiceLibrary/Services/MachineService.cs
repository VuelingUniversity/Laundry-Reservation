using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWash.Core.Interfaces;
using WundaWash.Core.Models;
using WundaWash.ServiceLibrary.Interfaces;

namespace WundaWash.ServiceLibrary.Services
{

    public class MachineService : IMachineService
    {
        private readonly IMachineRepository _machineRepository;

        public MachineService(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }
        public List<Machine> GetAllMachinesAvaible()
        {
            return _machineRepository.GetMachinesAvaible();
        }
    }
}
