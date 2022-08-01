using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Dtos.Interfaces;

namespace Udemy.AdvertisementApp.Dtos.GenderDtos
{
    public class GenderUpdateDto : IUpdateDto
    {
        public int Id { get; set; }

        public string Defination { get; set; }
    }
}
