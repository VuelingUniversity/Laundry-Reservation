using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWash.Core.Models;

namespace WundaWash.Core.Interfaces
{
    public interface IMachineRepository
    {
        List<Machine> GetMachinesAvaible();

    }
}
