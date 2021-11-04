using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WundaWashReservations.Core.Models;
using WundaWashReservations.Core.Services;

namespace WundaWashReservations.MachineApi.Infra.Repositories
{
    public class MachineApiRepository : IMachineApiRepository
    {
        private readonly string _url = ConfigurationManager.AppSettings["MachineApiUrl"];

        public bool LockMachine(MachineLockRequest lockRequest)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers["Content-type"] = "application/json";
                    client.Encoding = Encoding.UTF8;
                    string bodyJson = JsonConvert.SerializeObject(lockRequest);
                    string ApiResponse = client.UploadString($"{_url}/Lock", bodyJson);
                    return bool.Parse(ApiResponse);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error in lock request to machine api");
                throw;
            }
        }

        public bool UnlockMachine(string reservationId)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers["Content-type"] = "application/json";
                    client.Encoding = Encoding.UTF8;
                    string bodyJson = JsonConvert.SerializeObject(reservationId);
                    string ApiResponse = client.UploadString($"{_url}/Unlock", bodyJson);
                    return bool.Parse(ApiResponse);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error in unlock request to machine api");
                throw;
            }
        }
    }
}