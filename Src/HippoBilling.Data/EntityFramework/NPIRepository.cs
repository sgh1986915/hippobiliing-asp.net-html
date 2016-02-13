using System.Data.Entity;
using Castle.Windsor;
using HippoBilling.Core.Data;

namespace HippoBilling.Data.EntityFramework
{
    public class NPIRepository:EfRepository
    {
        private readonly IWindsorContainer _container;

        public NPIRepository(IWindsorContainer container, IProvider<DbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _container = container;
        }

        protected override DbContext DbContext
        {
            get
            {
                return _container.Resolve<DbContext>("NPIRecordContext");
            }
        }
    }
}
