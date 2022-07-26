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
    public class AdvertisementAppUserStatusConfiguration : IEntityTypeConfiguration<AdversitementAppUserStatus>
    {
        public void Configure(EntityTypeBuilder<AdversitementAppUserStatus> builder)
        {
            builder.Property(x => x.Defination).IsRequired().HasMaxLength(400);
        }
    }
}
