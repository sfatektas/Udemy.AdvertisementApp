using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Bussines.AutoMapper;

namespace Udemy.AdvertisementApp.Bussines.Helpers
{
    public static class ProfileHelper 
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile> { new AppUserProfile(), new ProvidedServiceProfile(), new AdvertisementProfile(), new GenderProfile() };
        }
    }
}
