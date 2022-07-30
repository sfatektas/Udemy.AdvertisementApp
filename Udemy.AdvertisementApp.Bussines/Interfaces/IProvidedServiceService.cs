using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Advertisement.Entities;
using Udemy.AdvertisementApp.Dtos.ProvidedServicesDtos;

namespace Udemy.AdvertisementApp.Bussines.Interfaces
{
    public interface IProvidedServiceService : 
        IService<ProvidedServiceCreateDto,ProvidedServiceUpdateDto,ProvidedServiceListDto,ProvidedService>
    {
    }
}
