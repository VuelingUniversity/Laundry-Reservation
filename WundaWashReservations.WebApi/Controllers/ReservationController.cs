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
        public bool CreateReservation([FromBody] CreateReservationRequest createRequest)
        {
            try
            {
                return _reservationService.CreateReservation(createRequest.ReservationDate, createRequest.PhoneNumber, createRequest.Email);
            }
            catch (Exception exception)
            {
                // log
                throw;
            }
        }

        [HttpPost]
        public bool ClaimReservation([FromBody] ClaimReservationRequest claimRequest)
        {
            try
            {
                return _reservationService.ClaimReservation(claimRequest.MachineId, claimRequest.Pin);
            }
            catch (Exception exception)
            {
                // log
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
                // log
                throw;
            }
        }
    }