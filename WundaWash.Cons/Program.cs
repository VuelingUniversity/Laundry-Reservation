using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWash.Core.Interfaces;
using WundaWash.Core.Models;
using WundaWash.Infra.Repositories;
using WundaWash.ServiceLibrary.Interfaces;
using WundaWash.ServiceLibrary.Services;

namespace WundaWash.Cons
{
    class Program
    {

        static void Main(string[] args)
        {
            IMachineService _machineService = new MachineService();
            IPatronService _patronService = new PatronService();
        }
    }
}
