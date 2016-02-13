using Castle.MicroKernel.Registration;
using HippoBilling.Core.Command;
using HippoBilling.Core.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Processor
{
    public class Installer : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {

            container.Register(
                Classes.FromThisAssembly().BasedOn(typeof(ICommandHandler<>)).WithServiceBase().LifestyleTransient(),
                Classes.FromThisAssembly().BasedOn(typeof(IEventHandler<>)).WithServiceBase().LifestyleTransient()
             );

        }
    }
}
