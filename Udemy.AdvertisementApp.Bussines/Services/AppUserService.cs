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
using Udemy.AdvertisementApp.Bussines.ValidationExtensions;
using Udemy.AdvertisementApp.DataAccess.Interfaces;
using Udemy.AdvertisementApp.Dtos.AppRoleDtos;
using Udemy.AdvertisementApp.Dtos.AppUserDtos;

namespace Udemy.AdvertisementApp.Bussines.Services
{
    public class AppUserService : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<AppUserCreateDto> _createValidator;
        private readonly IValidator<AppUserLoginDto> _loginUserValidator;

        public AppUserService(IMapper mapper, IUow uow, IValidator<AppUserCreateDto> createValidator, IValidator<AppUserUpdateDto> updateValidator
, IValidator<AppUserLoginDto> loginUserValidator)
            : base(mapper, createValidator, updateValidator, uow)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _loginUserValidator = loginUserValidator;
        }
        //Custome Service Methods 

        public async Task<IResponse<AppUserCreateDto>> CreateUserWithRoleAsync(AppUserCreateDto dto, int roleId)
        {
            var result = await _createValidator.ValidateAsync(dto);
            if (result.IsValid)
            {
                var user = _mapper.Map<AppUser>(dto);
                await _uow.GetRepository<AppUserRole>().CreateAsync(new AppUserRole
                {
                    AppRoleId = roleId,
                    AppUser = user
                });
                await _uow.SaveChangesAsync();
                return new Response<AppUserCreateDto>(ResponseType.Success, dto);
            }
            else
                return new Response<AppUserCreateDto>(ResponseType.ValidationError, dto, result.ConvertToErrorList());
        }
        public async Task<IResponse<AppUserListDto>> CheckUser(AppUserLoginDto dto)
        {
            var result = await _loginUserValidator.ValidateAsync(dto);
            if (result.IsValid)
            {
                var user = await _uow.GetRepository<AppUser>().GetByFilterAsync(x => x.Username == dto.Username && x.Password == dto.Password);
                if (user == null)
                {
                    return new Response<AppUserListDto>("ilgili kişi bulunamadı.", ResponseType.NotFound);
                }
                var mappedUser = _mapper.Map<AppUserListDto>(user);
                return new Response<AppUserListDto>(ResponseType.Success, mappedUser);
            }
            return new Response<AppUserListDto>(ResponseType.ValidationError, _mapper.Map<AppUserListDto>(dto), result.ConvertToErrorList());
        }
        public async Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsync(int userId)
        {
            //AppUserRoles tablosundaki userId ye eşit olan rolleri çekiyoruz.
            var roles = await _uow.GetRepository<AppRole>().GetAllAsync(x => x.AppUserRoles.Any(x => x.AppUserId == userId));
            if (roles == null)
                return new Response<List<AppRoleListDto>>("Kullanıcıya ait herhangi bir rol bulunamadı.", ResponseType.NotFound);
            var mappedData = _mapper.Map<List<AppRoleListDto>>(roles);
            return new Response<List<AppRoleListDto>>(ResponseType.Success, mappedData);
        }
    }

}
