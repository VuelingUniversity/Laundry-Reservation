using Laundry_Reservation.Domain.Models;
using Laundry_Reservation.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaundryReservations.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReservationsController : Controller
    {
        private IReservationService _reservation;

        public ReservationsController(IReservationService reservation)
        {
            _reservation = reservation;
        }

        [HttpGet]
        public IEnumerable<Reservation> GetReservations()
        {
            return _reservation.GetReservations();
        }

        [HttpPost]
    }
}