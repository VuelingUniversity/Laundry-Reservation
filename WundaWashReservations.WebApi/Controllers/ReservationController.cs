using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WundaWashReservations.ServiceLibrary.Interfaces;
using WundaWashReservations.WebApi.Models;

namespace WundaWashReservations.WebApi.Controllers
{
    public class ReservationController : ApiController
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public bool CreateReservation([FromBody] CreateReservationRequest reservationRequest)
        {
            try
            {
                return _reservationService.CreateReservation(reservationRequest.ReservationDate, reservationRequest.PhoneNumber, reservationRequest.Email);
            }
            catch (Exception exception)
            {
                // log
                throw;
            }
        }

        // PUT: api/Reservation/5
        //[ActionName("Thumbnail")] Con esto se especifica el nombre del action en lugar del del metodo.
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}