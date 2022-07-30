using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Advertisement.Entities;
using Udemy.AdvertisementApp.Bussines.Interfaces;
using Udemy.AdvertisementApp.DataAccess.Interfaces;
using Udemy.AdvertisementApp.Dtos.AppUserDtos;
using Udemy.AdvertisementApp.Dtos.ProvidedServicesDtos;

namespace Udemy.AdvertisementApp.Bussines.Services
{
    public class ProvidedServiceService :
        Service<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedService>,IProvidedServiceService
    {
        public ProvidedServiceService(IMapper mapper, IUow uow, IValidator<ProvidedServiceCreateDto> createValidator, IValidator<ProvidedServiceUpdateDto> updateValidator
            )
            : base(mapper, createValidator, updateValidator, uow)
        {
        }
    }
}
