using System.Data.Entity;
using HippoBilling.Domain.Practices;

namespace HippoBilling.Data.EntityFramework
{
    public class NPIRecordContext : DbContext
    {
        public NPIRecordContext()
            : base("name=NPIRecordContext")
        {

        }

        public DbSet<NPIRecord> NPIRecords;

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NPIRecord>().Ignore(x => x.Id).HasKey(x=>x.NPI);

            base.OnModelCreating(modelBuilder);
        }
    }
}
