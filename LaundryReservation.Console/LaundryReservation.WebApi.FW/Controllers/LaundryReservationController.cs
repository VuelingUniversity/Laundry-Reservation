using LaundryReservation.Services.Managers;
using LaundryServices.Core.Core;
using LaundryServices.Core.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace LaundryReservation.WebApi.FW.Controllers
{     
    public class LaundryReservationController: ApiController
    {
        private LaundryManager _laundryManager;

        public LaundryReservationController(IMachineRepository machineRepository, IReservationRepository reservationRepository)
        {
            _laundryManager = new LaundryManager(machineRepository, reservationRepository);
        }

        [HttpGet()]
        public List<Reservation> GetReservation()
        {
            return _laundryManager.GetReservations();
        }

    }
}