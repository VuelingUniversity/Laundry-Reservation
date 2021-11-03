using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WundaWash.Core.Models;
using WundaWash.ServiceLibrary.Interfaces;

namespace WundaWash.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MachineController : ControllerBase
    {
        private readonly IMachineService _machineService;

        public MachineController(IMachineService machineService)
        {
            _machineService = machineService;
        }

        [HttpGet]
        public List<Machine> GetAllMachineAvaible()
        {
            return _machineService.GetAllMachinesAvaible();
        }
    }
}
