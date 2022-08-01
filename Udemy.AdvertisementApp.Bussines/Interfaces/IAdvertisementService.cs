using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Adversitement.Common.Interfaces;
using Udemy.AdvertisementApp.Dtos.AdversitementDtos;

namespace Udemy.AdvertisementApp.Bussines.Interfaces
{
    public interface IAdvertisementService : IService<AdvertisementCreateDto,AdvertisementUpdateDto,AdvertisementListDto,Entities.Adversitement>

    {
        Task<IResponse<List<AdvertisementListDto>>> GetAllActiveAsync();
    }
}
