using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WundaWashMachine.ServiceLibrary.Interfaces;
using WundaWashMachine.WebApi.Models;

namespace WundaWashMachine.WebApi.Controllers
{
    public class MachineController : ApiController
    {
        private readonly IMachineService _machineService;

        public MachineController(IMachineService machineService)
        {
            _machineService = machineService;
        }

        [HttpPost]
        public bool Lock([FromBody] LockRequest lockRequest)
        {
            try
            {
                return _machineService.Lock(lockRequest.MachineNumber, lockRequest.ReservationId, lockRequest.ReservationDate, lockRequest.Pin);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public bool Unlock([FromBody] string reservationId)
        {
            try
            {
                return _machineService.Unlock(reservationId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}