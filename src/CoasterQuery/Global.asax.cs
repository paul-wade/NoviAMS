using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CoasterQuery.App_Start;
using System.Web.Http;
using System.Web.Http.Cors;
using Autofac;
using Autofac.Integration.WebApi;
using CoasterQuery.Business;
using CoasterQuery.Business.Services;
using CoasterQuery.Data.Models;
using CoasterQuery.Data.Repositories;

namespace CoasterQuery
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;
            config.EnableCors();
            AutofacConfig.Register(config);

        }
    }
}
