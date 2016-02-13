using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HippoBilling.Data.EntityFramework.Initializers;
using HippoBilling.Domain;
using HippoBilling.Domain.Accounts;
using HippoBilling.Domain.Addresses;
using HippoBilling.Domain.Patients;
using HippoBilling.Domain.Practices;
using HippoBilling.Domain.Authorizations;
using HippoBilling.Domain.Insurances;

namespace HippoBilling.Data.EntityFramework
{
    [DbConfigurationType(typeof (DbContextConfiguration))]
    public class HippoBillingContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PasswordRecovery> PasswordRecoveries { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Speciality> Specialities { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<Practice> Practices { get; set; }

        public DbSet<PermissionModule> PermissionModules { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<PracticeUser> PracticeUsers { get; set; }

        public DbSet<UserPermission> UserPermissions { get; set; }

        public DbSet<ServicePlace> ServicePlaces { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientNote> PatientNotes { get; set; }

        public DbSet<FavoritePhysician> FavoritePhysicians { get; set; }

        public DbSet<Authorization> Authorizations { get; set; }
        public DbSet<FavoritePayer> FavoritePayers { get; set; }
        public DbSet<Payer> Payers { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<PolicyType> PolicyTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionModule>().Ignore(e => e.Id).HasKey(e => e.FullName);

            modelBuilder.Entity<State>().Ignore(e => e.Id).HasKey(e => e.Code);

            modelBuilder.Entity<PracticeUser>()
                .Ignore(x => x.Id)
                .HasKey(x => new { x.UserId, x.PracticeId })
                .HasRequired(x => x.Practice)
                .WithMany(x => x.PracticeUsers)
                .HasForeignKey(x => x.PracticeId);

            modelBuilder.Entity<PracticeUser>().HasRequired(x => x.User).WithMany().HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserPermission>()
                .Ignore(x => x.Id)
                .HasKey(x => new { x.PracticeId, x.UserId, x.ModuleId })
                .HasRequired(x => x.User)
                .WithMany(x => x.UserPermissions)
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<UserPermission>().HasRequired(x => x.Module).WithMany().HasForeignKey(x => x.ModuleId);
            modelBuilder.Entity<UserPermission>()
                .HasRequired(x => x.Practice)
                .WithMany()
                .HasForeignKey(x => x.PracticeId);

            modelBuilder.Entity<ServicePlace>()
                .Ignore(x => x.Id).HasKey(x => x.Code);

            //modelBuilder.Configurations.AddFromAssembly(this.GetType().Assembly);

            modelBuilder.Entity<Patient>()
                .Property(p => p.PatientNo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<FavoritePhysician>()
                .Ignore(p => p.Id)
                .HasKey(p => new { p.NPI, p.PracticeId })
                .HasRequired(p => p.Practice)
                .WithMany()
                .HasForeignKey(x => x.PracticeId);

            modelBuilder.Entity<FavoritePayer>()
                .Ignore(x => x.Id)
                .HasKey(x => new { x.PayerId, x.PracticeId })
                .HasRequired(x => x.Payer)
                .WithMany()
                .HasForeignKey(x => x.PayerId);
            modelBuilder.Entity<FavoritePayer>()
                .HasRequired(x => x.Practice)
                .WithMany()
                .HasForeignKey(x => x.PracticeId);


            base.OnModelCreating(modelBuilder);
        }
    }
}