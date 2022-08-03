using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdversitementApp.Common.Enums;
using Udemy.AdvertisementApp.Dtos.Interfaces;

namespace Udemy.AdvertisementApp.Dtos.AdvertisementAppUserDtos
{
    public class AdvertisementAppUserCreateDto : ICreateDto
    {
        public int AdvertisementId { get; set; }

        public int AppUserId { get; set; }

        public int AdversitementUserStatusId { get; set; } = (int)AdvertisementUserStatusType.Basvuruldu;

        public int MilitaryStatusId { get; set; }

        public int WorkExperience { get; set; }

        public string CvPath { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
