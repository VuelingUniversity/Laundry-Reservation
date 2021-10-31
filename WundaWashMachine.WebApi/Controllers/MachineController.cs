using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WundaWashMachine.WebApi.Models;

namespace WundaWashMachine.WebApi.Controllers
{
    public class MachineController : ApiController
    {
        [HttpPost]
        public bool Lock([FromBody] LockRequest lockRequest)
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public bool Unlock([FromBody] UnlockRequest unlockRequest)
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}