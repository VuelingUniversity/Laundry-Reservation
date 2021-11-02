using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WundaWashReservations.Core.Models;
using WundaWashReservations.ServiceLibrary.Interfaces;

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
        public bool CreateReservation([FromBody] CreateReservationRequest createRequest)
        {
            try
            {
                return _reservationService.CreateReservation(createRequest);
            }
            catch (Exception exception)
            {
                Log.Error($"Internal error at CreateReservation with request: {createRequest}", exception);
                throw;
            }
        }

        [HttpPost]
        public bool ClaimReservation([FromBody] ClaimReservationRequest claimRequest)
        {
            try
            {
                return _reservationService.ClaimReservation(claimRequest);
            }
            catch (Exception exception)
            {
                Log.Error($"Internal error at ClaimReservation with request: {claimRequest}", exception);
                throw;
            }
        }

        [HttpPost]
        public bool CancelReservation([FromBody] string reservationId)
        {
            try
            {
                return _reservationService.CancelReservation(reservationId);
            }
            catch (Exception exception)
            {
                // decorador
                Log.Error($"Internal error at CancelReservation with request: {reservationId}", exception);
                throw;
            }
        }
    }
}