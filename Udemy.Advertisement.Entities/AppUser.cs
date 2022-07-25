using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Advertisement.Entities
{
    public class AppUser : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int GenderId { get; set; }

        //Nav Prop

        public Gender Gender { get; set; }

        public List<AppUserRole> AppUserRoles { get; set; }

        public List<AdvertisementUser> AdvertisementUsers { get; set; }

    }
}
