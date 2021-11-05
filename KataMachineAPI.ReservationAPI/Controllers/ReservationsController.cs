using KataMachineAPI.Core.Models;
using KataMachineAPI.Core.Services;
using KataMachineAPI.Infrastructure.Repositories;
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
    public class ReservationsController : ControllerBase
    {
        private LaundryManager _laundryManager;

        public ReservationsController(IMachineRepository _machRepo, IReservationRepository _resRepo)
        {
            _laundryManager = new LaundryManager(_machRepo, _resRepo);
        }

        public List<Reservation> Get()
        {
            return _laundryManager.GetReservations();
        }

        [HttpPost("AddReservation")]
        public bool AddReservation(Reservation reservation)
        {
            Log.Information($"ReservationController: Someone claims Reservation [ID : {reservation.Id}]");
            return _laundryManager.CreateReservation(reservation);
        }

        [Route("RemoveReservation/{id}")]
        [HttpGet]
        public bool RemoveReservation(int id)
        {
            return _laundryManager.DeleteReservation(id);
        }
    }
}
