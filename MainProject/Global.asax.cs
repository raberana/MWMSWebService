using MainProject.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MainProject
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DatabaseConfig.MigrateDatabase("Server=ff4c7673-21c8-4089-93c4-a1e500291e65.sqlserver.sequelizer.com;Database=dbff4c767321c8408993c4a1e500291e65;User ID=dinbhyfbgnktskik;Password=gWQ2FQgQJVudrdeh3LFDvqysvcPgvYiXpFDmiwBzmYCEKjTmAqZgZXdYwwEDbauS;");
        }
    }
}