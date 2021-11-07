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
        private LaundryManager _laundryManager;

        public LaundryServiceController(IMachineRepository machineRepository, IReservationRepository reservationRepository)
        {
            _laundryManager = new LaundryManager(machineRepository, reservationRepository);
        }

        [HttpGet]
        public List<Reservation> GetReservation()
        {
            return _laundryManager.GetReservations();
        }
    }
}
