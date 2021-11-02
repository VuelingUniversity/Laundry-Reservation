using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using WundaWashReservations.ADO.Infra.Repositories;
using WundaWashReservations.Core.Services;
using WundaWashReservations.Email.Infra;
using WundaWashReservations.Email.Infra.Repositories;
using WundaWashReservations.MachineApi.Infra.Repositories;
using WundaWashReservations.ServiceLibrary.Interfaces;
using WundaWashReservations.ServiceLibrary.Services;

namespace WundaWashReservations.WebApi.App_Start
{
    public class IocConfiguration
    {
        public static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ReservationService>().As<IReservationService>();
            builder.RegisterType<EmailRepository>().As<IEmailRepository>();
            builder.RegisterType<ReservationRepository>().As<IReservationRepository>();
            builder.RegisterType<MachineApiRepository>().As<IMachineApiRepository>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}