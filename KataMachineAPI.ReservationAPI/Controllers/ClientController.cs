using KataMachineAPI.Core.Services;
using KataMachineAPI.ServiceLibrary.Manager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KataMachineAPI.ReservationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private LaundryManager _laundryManager;

        public ClientController(IMachineRepository _machRepo, IReservationRepository _resRepo)
        {
            _laundryManager = new LaundryManager(_machRepo, _resRepo);
        }

        [Route("ClaimReservation/{id}/{PIN}")]
        [HttpPost]
        public bool ClaimReservation(int id, int PIN)
        {
            return _laundryManager.ClaimReservation(id, PIN);
        }

        [Route("CancelReservation/{id}")]
        [HttpPost]
        public void CancelReservation(int id)
        {
            _laundryManager.DeleteReservation(id);
        }
    }
}