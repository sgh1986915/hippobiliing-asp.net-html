using Castle.MicroKernel.Registration;
using HippoBilling.Core.Data;
using HippoBilling.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Data
{
    public class Installer : IWindsorInstaller
    {
		public void Install(Castle.Windsor.IWindsorContainer container,
            Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(
                Component.For<IProvider<DbContext>>()
                    .ImplementedBy<DbContextProvider>().LifestyleSingleton(),
                Component.For(typeof (DbContext))
                    .ImplementedBy(typeof (HippoBillingContext))
                    .LifestylePerWebRequest(),

                Component.For(typeof (DbContext))
                    .ImplementedBy(typeof (NPIRecordContext))
                    .LifestylePerWebRequest().Named("NPIRecordContext"),

                Component.For(typeof (IRepository))
                    .ImplementedBy(typeof (EfRepository))
                    .LifestyleSingleton()
                ,

                Component.For(typeof (IRepository))
                    .ImplementedBy(typeof (NPIRepository))
                    .LifestyleSingleton().Named("NPIRecordRepository"));
        }
    }
}
