using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using HippoBilling.Core.Infrastructure;
using HippoBilling.Core.Windsor;
using HippoBilling.Web.Mvc.ControllerFactory;
using HippoBilling.Web.Mvc.TypeFinder;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HippoBilling.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

  
            var container = new WindsorContainer();

            container.Register(
                    Component.For<IWindsorContainer>().Instance(container),
                    Component.For<IServiceLocator>().ImplementedBy<WindsorServiceLocatorAdapter>().LifestyleSingleton(),
                    Component.For<ITypeFinder>().ImplementedBy<WebAppTypeFinder>().LifestyleSingleton(),
                    Component.For<IControllerFactory>().ImplementedBy<WindsorControllerFactory>().LifestyleSingleton(),
                    Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient()
                );
            var serviceLocator = container.Resolve<IServiceLocator>();
            ServiceLocator.SetLocatorProvider(()=>serviceLocator);
         
            container.Install(FromAssembly.InThisApplication());
            ControllerBuilder.Current.SetControllerFactory(container.Resolve<IControllerFactory>());
        }
        public void Page_Error(object sender, EventArgs e)
        {
           //log
        }

        public void Application_Error(object sender, EventArgs e)
        {
            //log
        }
    }
}
