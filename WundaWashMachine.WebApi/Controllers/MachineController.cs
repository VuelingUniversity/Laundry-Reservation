using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WundaWashMachine.Core.Models;
using WundaWashMachine.ServiceLibrary.Interfaces;

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
                return _machineService.Lock(lockRequest);
            }
            catch (Exception exception)
            {
                Log.Error(exception, $"Internal error at Lock with request: {JsonConvert.SerializeObject(lockRequest)}");
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
            catch (Exception exception)
            {
                Log.Error(exception, $"Internal error at Unlock with reservationId: {reservationId}");
                throw;
            }
        }
    }
}