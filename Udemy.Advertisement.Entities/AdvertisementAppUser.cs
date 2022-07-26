using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Entities;

namespace Udemy.Advertisement.Entities
{
    public class AdvertisementAppUser :BaseEntity
    {
        public int AdvertisementId { get; set; }

        public Adversitement Adversitement { get; set; }

        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public int AdversitementUserStatusId { get; set; }

        public AdversitementAppUserStatus AdversitementUserStatus { get; set; }

        public int MilitaryStatusId { get; set; }

        public MilitaryStatus MilitaryStatus { get; set; }

        public int WorkExperience { get; set; }

        public string CvPath { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
