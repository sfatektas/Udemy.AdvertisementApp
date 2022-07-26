using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Advertisement.Entities;
using Udemy.AdvertisementApp.Entities;
using Udemy.AdvertisementApp.DataAccess.Configurations;


namespace Udemy.AdvertisementApp.DataAccess.Contexts
{
    public class AdvertisementContext : DbContext
    {
        public AdvertisementContext(DbContextOptions<AdvertisementContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdvertisemenetConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementAppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementAppUserStatusConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new MilitaryStatusConfiguration());
            modelBuilder.ApplyConfiguration(new ProvidedServiceConfiguration());
        }
        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<AppRole> AppRoles { get; set; }

        public DbSet<AppUserRole> AppUserRoles { get; set; }

        public DbSet<AdversitementAppUserStatus> AdversitementUserStatuses { get; set; }

        public DbSet<Udemy.AdvertisementApp.Entities.Adversitement> Adversitements { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<MilitaryStatus> MilitaryStatuses { get; set; }

        public DbSet<AdversitementAppUserStatus> AdversitementUsers { get; set; }

        public DbSet<ProvidedService> ProvidedServices { get; set; }
    }
}
