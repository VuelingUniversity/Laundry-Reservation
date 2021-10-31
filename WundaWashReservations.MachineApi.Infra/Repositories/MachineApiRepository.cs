using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WundaWashReservations.Core.Services;
using WundaWashReservations.MachineApi.Infra.Models;

namespace WundaWashReservations.MachineApi.Infra.Repositories
{
    public class MachineApiRepository : IMachineApiRepository
    {
        private readonly string _url = @"http://localhost...";

        public bool LockMachine(string reservationId, int machineNumber, DateTime reservationDate, int pin)
        {
            try
            {
                MachineApiLockRequest lockRequest = new MachineApiLockRequest
                {
                    ReservationId = reservationId,
                    MachineNumber = machineNumber,
                    ReservationDate = reservationDate,
                    Pin = pin
                };

                using (WebClient client = new WebClient())
                {
                    client.Headers["Content-type"] = "application/json";
                    client.Encoding = Encoding.UTF8;
                    string bodyJson = JsonConvert.SerializeObject(lockRequest);
                    string ApiResponse = client.UploadString($"{_url}/LockMachine", bodyJson);
                    return bool.Parse(ApiResponse);
                }
            }
            catch (Exception)
            {
                // log excepcion api
                throw;
            }
        }

        public bool UnlockMachine(string reservationId, int machineNumber)
        {
            try
            {
                MachineApiUnlockRequest unlockRequest = new MachineApiUnlockRequest
                {
                    ReservationId = reservationId,
                    MachineNumber = machineNumber
                };
                using (WebClient client = new WebClient())
                {
                    client.Headers["Content-type"] = "application/json";
                    client.Encoding = Encoding.UTF8;
                    string bodyJson = JsonConvert.SerializeObject(unlockRequest);
                    string ApiResponse = client.UploadString($"{_url}/UnlockMachine", bodyJson);
                    return bool.Parse(ApiResponse);
                }
            }
            catch (Exception)
            {
                // log excepcion api
                throw;
            }
        }
    }
}