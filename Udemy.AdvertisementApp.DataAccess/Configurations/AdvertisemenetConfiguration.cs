using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Advertisement.Entities;
using Udemy.AdvertisementApp.Entities;

namespace Udemy.AdvertisementApp.DataAccess.Configurations
{
    public class AdvertisemenetConfiguration : IEntityTypeConfiguration<AdvertisementApp.Entities.Adversitement>
    {
        public void Configure(EntityTypeBuilder<AdvertisementApp.Entities.Adversitement> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(300);
            builder.Property(x => x.CreatedTime).HasDefaultValueSql("getdate()");
            //Default olarak sql veri tabanı tarafında zaman ataması yapılır.
            //ilişkileri çok olan yapıda tanımlayacağım
        }
    }
}
