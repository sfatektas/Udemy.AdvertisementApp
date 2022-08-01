using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Advertisement.Entities;

namespace Udemy.AdvertisementApp.DataAccess.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            //Aynı Role birden fazla şekilde eklenmesin.
            builder.HasIndex(x => new { x.Defination }).IsUnique();

            builder.Property(x => x.Defination).IsRequired().HasMaxLength(100);

            //Seed Data

            builder.HasData(new AppRole
            {
                Id = 1,
                Defination = "Admin"
            },
            new AppRole
            {
                Id = 2,
                Defination = "Member"
            });
        }
    }
}
