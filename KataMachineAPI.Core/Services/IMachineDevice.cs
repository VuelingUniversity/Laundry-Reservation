using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataMachineAPI.Core.Services
{
    public interface IMachineDevice
    {
        bool Lock(string reservationId, DateTime reservationDateTime, int pin);

        void Unlock(string reservationId);
    }
}