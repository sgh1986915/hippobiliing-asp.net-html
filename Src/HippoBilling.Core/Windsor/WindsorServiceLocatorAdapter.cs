using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Windsor;
using Microsoft.Practices.ServiceLocation;
using Castle.Windsor.Installer;

namespace HippoBilling.Core.Windsor
{
    public class WindsorServiceLocatorAdapter : IServiceLocator
    {
        private readonly IWindsorContainer _container;

        public WindsorServiceLocatorAdapter(IWindsorContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            return _container.Resolve(serviceType);
        }

        public object GetInstance(Type serviceType)
        {
            return _container.Resolve(serviceType);
        }

        public object GetInstance(Type serviceType, string key)
        {
            return _container.Resolve(key, serviceType);
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.ResolveAll(serviceType).OfType<object>();
        }

        public TService GetInstance<TService>()
        {
            return _container.Resolve<TService>();
        }

        public TService GetInstance<TService>(string key)
        {
            return _container.Resolve<TService>(key);
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return _container.ResolveAll<TService>();
        }
    }
}
