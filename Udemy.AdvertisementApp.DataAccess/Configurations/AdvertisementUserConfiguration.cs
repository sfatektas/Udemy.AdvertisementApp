using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Entities;
using Udemy.Advertisement.Entities;

namespace Udemy.AdvertisementApp.DataAccess.Configurations
{
    public class AdvertisementAppUserConfiguration : IEntityTypeConfiguration<AdvertisementAppUser>
    {
        public void Configure(EntityTypeBuilder<AdvertisementAppUser> builder)
        {
            //Bir kullanıcı herbir başvuruya sadece 1 defa başvursun
            builder.HasIndex(x => new { x.AppUserId, x.AdvertisementId }).IsUnique();

            builder.Property(x => x.AdvertisementId).IsRequired();
            builder.Property(x => x.AdversitementUserStatusId).IsRequired();
            builder.Property(x => x.MilitaryStatusId).IsRequired();
            builder.Property(x => x.AppUserId).IsRequired();
            builder.Property(x => x.WorkExperience).IsRequired();
            builder.Property(x => x.CvPath).IsRequired().HasMaxLength(500);

            //İlişkiler tanımlandı

            builder.HasOne(x => x.Adversitement).WithMany(x => x.AdvertisementAppUsers).HasForeignKey(x => x.AdvertisementId);

            builder.HasOne(x => x.AdversitementUserStatus).WithMany(x => x.AdvertisementAppUsers).HasForeignKey(x => x.AdversitementUserStatusId);

            builder.HasOne(x => x.AppUser).WithMany(x => x.AdvertisementUsers).HasForeignKey(x => x.AppUserId);

            builder.HasOne(x => x.MilitaryStatus).WithMany(x => x.AdvertisementUsers).HasForeignKey(x => x.MilitaryStatusId);

        }
    }
}
