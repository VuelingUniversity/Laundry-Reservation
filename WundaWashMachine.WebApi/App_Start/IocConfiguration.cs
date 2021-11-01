using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using WundaWashMachine.Core.Services;
using WundaWashMachine.EF.Infra.Context;
using WundaWashMachine.EF.Infra.Repositories;
using WundaWashMachine.ServiceLibrary.Interfaces;
using WundaWashMachine.ServiceLibrary.Services;

namespace WundaWashMachine.WebApi.App_Start
{
    public class IocConfiguration
    {
        public static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<MachineService>().As<IMachineService>();
            builder.RegisterType<MachineRepository>().As<IMachineRepository>();
            builder.RegisterType<WundaWashMachineContext>().InstancePerRequest();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}