using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Adversitement.Common;
using Udemy.Adversitement.Common.Interfaces;
using Udemy.Advertisement.Entities;
using Udemy.AdvertisementApp.Bussines.Interfaces;
using Udemy.AdvertisementApp.DataAccess.Interfaces;
using Udemy.AdvertisementApp.Dtos.AppUserDtos;

namespace Udemy.AdvertisementApp.Bussines.Services
{
    public class AppUserService : Service<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser>,IAppUserService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<AppUserCreateDto> _createValidator;
        private readonly IValidator<AppUserUpdateDto> _updateValidator;

        public AppUserService(IMapper mapper , IUow uow , IValidator<AppUserCreateDto> createValidator,IValidator<AppUserUpdateDto> updateValidator
            )
            : base(mapper,createValidator,updateValidator,uow)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
        }
        //Custome Service Methods 

        public async Task<IResponse<AppUserCreateDto>> CreateUserWithAsync(AppUserCreateDto dto)
        {
            var result =  await _createValidator.ValidateAsync(dto);
            if (result.IsValid)
            {
                await _uow.GetRepository<AppUser>().CreateAsync(_mapper.Map<AppUser>(dto));
            }
            return new Response<AppUserCreateDto>(ResponseType.Success);
        }
    }
}
