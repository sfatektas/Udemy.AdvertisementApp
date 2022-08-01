using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Dtos.AdversitementDtos;

namespace Udemy.AdvertisementApp.Bussines.AutoMapper
{
    public class AdvertisementProfile : Profile
    {
        public AdvertisementProfile()
        {
            CreateMap<Entities.Adversitement, AdvertisementCreateDto>().ReverseMap();
            CreateMap<Entities.Adversitement, AdvertisementListDto>().ReverseMap();
            CreateMap<Entities.Adversitement, AdvertisementCreateDto>().ReverseMap();
        }
    }
}
