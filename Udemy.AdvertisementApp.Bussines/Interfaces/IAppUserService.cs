using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Advertisement.Entities;
using Udemy.AdvertisementApp.Dtos.AppUserDtos;

namespace Udemy.AdvertisementApp.Bussines.Interfaces
{
    public interface IAppUserService :
        IService<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser>
    {
    }
}
