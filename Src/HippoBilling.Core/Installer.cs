using Castle.MicroKernel.Registration;
using HippoBilling.Core.Command;
using HippoBilling.Core.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Core
{
    public class Installer : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {

            container.Register(
                Component.For<IEventEmitter>().ImplementedBy<EventEmitter>().LifestyleSingleton(),
                Component.For<IAsyncEventEmitter>().ImplementedBy<AsyncEventEmitter>().LifestyleSingleton(),
                Component.For<ICommandService>().ImplementedBy<CommandService>().LifestyleSingleton()
             );

        }
    }
}
