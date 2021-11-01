using KataMachineAPI.Core.Models;
using KataMachineAPI.Infrastructure.Repositories;
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
    public class ReservationsController : ControllerBase
    {
        private LaundryManager _laundryManager;

        public ReservationsController()
        {
            _laundryManager = new LaundryManager(new MachineRepository(null), new ReservationRepository(null));
        }

        public List<Reservation> Get()
        {
            return _laundryManager.GetReservations();
        }

        [HttpPost("AddReservation")]
        public bool AddReservation(Reservation reservation)
        {
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