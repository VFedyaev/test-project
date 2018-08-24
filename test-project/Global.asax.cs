using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using test_project.App_Start;

namespace test_project
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Unity Dependency Injection
            UnityConfig.RegisterComponents();

            //// Ninject Dependency Inejection
            //NinjectModule cfg = new NinjectConfig("DefaultConnection");
            //var kernel = new StandardKernel(cfg);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
