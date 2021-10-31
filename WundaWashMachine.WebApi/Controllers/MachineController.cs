using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WundaWashMachine.WebApi.Controllers
{
    public class MachineController : ApiController
    {
        // GET: api/Machine
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Machine/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Machine
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Machine/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Machine/5
        public void Delete(int id)
        {
        }
    }
}