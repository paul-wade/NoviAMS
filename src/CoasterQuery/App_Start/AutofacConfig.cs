using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using CoasterQuery.Business.Services;
using CoasterQuery.Data.Models;
using CoasterQuery.Data.Repositories;

namespace CoasterQuery.App_Start
{
    public class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //app registrations.
            builder.RegisterType<AmusementParkRepository>().As<IRepository<Park>>();
            builder.RegisterType<ParkService>().As<IParkService>();
            builder.RegisterType<MappingService>().As<IMappingService>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}