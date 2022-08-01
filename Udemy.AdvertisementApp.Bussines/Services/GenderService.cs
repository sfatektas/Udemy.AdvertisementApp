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
using Udemy.AdvertisementApp.Dtos.GenderDtos;

namespace Udemy.AdvertisementApp.Bussines.Services
{
    public class GenderService : Service<GenderCreateDto,GenderUpdateDto,GenderListDto,Gender>,IGenderService
    {
        //private readonly IMapper _mapper;
        //private readonly IUow _uow;
        //private readonly IValidator<GenderCreateDto> _createValidator;
        //private readonly IValidator<GenderUpdateDto> _updateValidator;

        public GenderService(IMapper mapper, IUow uow, IValidator<GenderCreateDto> createValidator, IValidator<GenderUpdateDto> updateValidator)
        :base(mapper,createValidator,updateValidator,uow)
        {
        }
    }
}
