using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Advertisement.Entities
{
    public class AdvertisementUser
    {
        public int AdvertisementId { get; set; }

        public Adversitement Adversitement { get; set; }

        public int UserId { get; set; }

        public AppUser AppUser { get; set; }

        public int AdversitementUserStatusId { get; set; }

        public AdversitementUserStatus AdversitementUserStatus { get; set; }

        public int MilitaryStatusId { get; set; }

        public MilitaryStatus MilitaryStatus { get; set; }

        public int WorkExperience { get; set; }

        public string CvPath { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
