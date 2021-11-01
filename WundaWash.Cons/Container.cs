using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWash.ServiceLibrary.Interfaces;
using WundaWash.ServiceLibrary.Services;

namespace WundaWash.Cons
{
    public class Container
    {
        public static IServiceProvider Build()
        {
            var Container = new ServiceCollection()
                .AddSingleton<IMachineService, MachineService>()
                .AddSingleton<IPatronService, PatronService>()
            return Container.BuildServiceProvider();
        }
    }
}
