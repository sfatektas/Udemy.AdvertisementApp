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

        public AppUserService(IMapper mapper , IUow uow , IValidator<AppUserCreateDto> createValidator,IValidator<AppUserUpdateDto> updateValidator
            )
            : base(mapper,createValidator,updateValidator,uow)
        {
        }
        //Custome Service Methods 
        //......
    }
}
