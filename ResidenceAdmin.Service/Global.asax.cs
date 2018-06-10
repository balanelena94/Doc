using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using ResidenceAdmin.DataAccess;
using ResidenceAdmin.DataAccess.Contracts;
using ResidenceAdmin.Persistency;
using RegistrationExtensions = WebApiContrib.IoC.Autofac.RegistrationExtensions;

namespace ResidenceAdmin.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SetupAutofac();
        }


        private static void SetupAutofac()
        {
            var builder = new ContainerBuilder();

            RegistrationExtensions.RegisterApiControllers(builder, Assembly.GetExecutingAssembly()); //Register WebApi Controllers

            builder.RegisterType<UserRepository>().As<IUserRepository>().ExternallyOwned().SingleInstance();
            builder.RegisterType<PersistencyContext>().As<IPersistencyContext>().ExternallyOwned().SingleInstance();
            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
