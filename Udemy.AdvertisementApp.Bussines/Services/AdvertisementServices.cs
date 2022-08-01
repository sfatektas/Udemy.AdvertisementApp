using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Adversitement.Common;
using Udemy.Adversitement.Common.Enums;
using Udemy.Adversitement.Common.Interfaces;
using Udemy.AdvertisementApp.Bussines.Interfaces;
using Udemy.AdvertisementApp.DataAccess.Interfaces;
using Udemy.AdvertisementApp.Dtos.AdversitementDtos;

namespace Udemy.AdvertisementApp.Bussines.Services
{
    public class AdvertisementServices : Service<AdvertisementCreateDto,AdvertisementUpdateDto,AdvertisementListDto,Entities.Adversitement> , IAdvertisementService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        
        public AdvertisementServices(IMapper mapper,IValidator<AdvertisementCreateDto> createvalidator, IValidator<AdvertisementUpdateDto> updatevalidator, IUow uow)
            :base(mapper,createvalidator,updatevalidator,uow)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IResponse<List<AdvertisementListDto>>> GetAllActiveAsync()
        {
            var data = await _uow.GetRepository<Entities.Adversitement>().GetAllAsync(x => x.Status==true,x=>x.CreatedTime,
               OrderByType.DESC);
            var mappedData = _mapper.Map<List<AdvertisementListDto>>(data);
            return new Response<List<AdvertisementListDto>>(ResponseType.Success,mappedData);
        }
    }
}
