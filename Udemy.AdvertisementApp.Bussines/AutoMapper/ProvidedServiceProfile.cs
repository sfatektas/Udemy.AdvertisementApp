using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Advertisement.Entities;
using Udemy.AdvertisementApp.Dtos.ProvidedServicesDtos;

namespace Udemy.AdvertisementApp.Bussines.AutoMapper
{
    public class ProvidedServiceProfile : Profile
    {
        public ProvidedServiceProfile()
        {
            CreateMap<ProvidedService, ProvidedServiceListDto>().ReverseMap();
            CreateMap<ProvidedService, ProvidedServiceCreateDto>().ReverseMap();
            CreateMap<ProvidedService, ProvidedServiceUpdateDto>().ReverseMap();
        }
    }
}
