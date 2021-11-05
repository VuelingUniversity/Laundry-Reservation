using KataMachineAPI.Core.Services;
using KataMachineAPI.ServiceLibrary.Manager;
using Microsoft.AspNetCore.Mvc;
using Serilog;
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
            Log.Information($"ClientController: Someone claims Reservation [PIN : {PIN} - Id : {id}]");
            return _laundryManager.ClaimReservation(id, PIN);
        }

        [Route("CancelReservation/{id}")]
        [HttpPost]
        public void CancelReservation(int id)
        {
            Log.Information($"ClientController: Someone cancelled his Reservation [Id : {id}]");
            _laundryManager.DeleteReservation(id);
        }
    }
}
