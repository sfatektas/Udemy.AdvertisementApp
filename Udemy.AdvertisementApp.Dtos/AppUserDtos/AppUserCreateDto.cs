using System;
using Udemy.AdvertisementApp.Dtos.Interfaces;

namespace Udemy.AdvertisementApp.Dtos
{
    public class AppUserCreateDto : ICreateDto
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int GenderId { get; set; }
    }
}
