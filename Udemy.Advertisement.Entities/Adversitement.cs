using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Advertisement.Entities;


namespace Udemy.AdvertisementApp.Entities
{
    public class Adversitement : BaseEntity
    {
        public string Title { get; set; }

        public bool Status { get; set; }

        public string Description { get; set; }

        public DateTime CreatedTime { get; set; } /*= DateTime.Now;*///default değer ile 
        //Yeni instance oluşunca otomatik atar.
        //Veritabanında oluşturulma zamanını atıyacağım 
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
