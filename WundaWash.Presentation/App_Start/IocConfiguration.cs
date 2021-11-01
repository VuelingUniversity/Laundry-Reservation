using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WundaWash.Core.Interfaces;
using WundaWash.Infra.Repositories;
using WundaWash.ServiceLibrary.Interfaces;
using WundaWash.ServiceLibrary.Services;

namespace WundaWash.Presentation.App_Start
{
    public static class IocConfiguration
    {
        public static IContainer Container { get; set; }

        public static T GetInstance<T>()
        {
            return Container.Resolve<T>();
        }

        public static void Configure()
        {
            var builder = new ContainerBuilder();

            RegisterRepositories(builder);
            RegisterServices(builder);
            RegisterControllers(builder);

            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<MachineService>().As<IMachineService>().SingleInstance();
            builder.RegisterType<PatronService>().As<IPatronService>().SingleInstance();
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<MachineRepository>().As<IMachineRepository>().SingleInstance();
            builder.RegisterType<PatronRepository>().As<IPatronRepository>().SingleInstance();
        }

        private static void RegisterControllers(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
        }
    }
}