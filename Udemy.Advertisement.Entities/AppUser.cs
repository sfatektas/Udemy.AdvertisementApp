using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Advertisement.Entities
{
    public class AppUser : BaseEntity
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int GenderId { get; set; }

        public Gender Gender { get; set; }

        //Nav Prop

        public List<AppUserRole> AppUserRoles { get; set; }

        public List<AdvertisementAppUser> AdvertisementUsers { get; set; }

    }
}
