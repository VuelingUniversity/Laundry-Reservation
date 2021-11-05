using Laundry_Reservation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laundry_Reservation.Domain.Services
{
    public interface IMachineService
    {
        Machine GetMachineById(int id);

        IEnumerable<Machine> GetMachines();
    }
}