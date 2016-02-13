using Castle.Windsor;
using HippoBilling.Core.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Data.EntityFramework
{
    public sealed class DbContextProvider:IProvider<DbContext>
    {
         private readonly IWindsorContainer _container;

         public DbContextProvider(IWindsorContainer container)
        {
            _container = container;
        }
        public DbContext Get()
        {
            return _container.Resolve<DbContext>();
        }
    }
}
