using LaundryReservation.Services.Managers;
using LaundryServices.Core.Core;
using LaundryServices.Core.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaundryReservation.ApiCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LaundryServiceController: ControllerBase
    {
       // private LaundryManager _laundryManager;
        private IMachineRepository _machineManager;

        public LaundryServiceController(IMachineRepository machineManager)
        {
            _machineManager = machineManager;
        }

        /*public LaundryServiceController(IMachineRepository machineRepository, IReservationRepository reservationRepository)
        {
            _laundryManager = new LaundryManager(machineRepository, reservationRepository);
        }*/

        [HttpGet]
        public List<Machine> GetAll()
        {
            return _machineManager.GetAllEnableMachine();
        }

    }
}
