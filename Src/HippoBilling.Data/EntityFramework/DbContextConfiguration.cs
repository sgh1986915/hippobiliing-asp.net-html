using HippoBilling.Data.EntityFramework.Initializers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Data.EntityFramework
{
    public class DbContextConfiguration : DbConfiguration
    {
        public DbContextConfiguration()
        {
            this.SetDatabaseInitializer(new InitializeWhenDatabaseCreated());
            this.SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }
}
