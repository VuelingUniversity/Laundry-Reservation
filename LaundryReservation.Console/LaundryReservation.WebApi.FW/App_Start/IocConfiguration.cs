using Autofac;
using Autofac.Integration.WebApi;
using LaundryReservation.Infraestructure.EF.Context;
using LaundryReservation.Infraestructure.EF.Respositories;
using LaundryReservation.Services.Managers;
using LaundryServices.Core.Services.IManager;
using LaundryServices.Core.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace LaundryReservation.WebApi.FW.App_Start
{
    public class IocConfiguration
    {
        public static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<LaundryManager>().As<ILaundryManager>();
            builder.RegisterType<MachineRepository>().As<IMachineRepository>();
            builder.RegisterType<ReservationRepository>().As<IReservationRepository>();
            builder.RegisterType<LaundryReservationServiceContext>().InstancePerRequest();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}