using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Udemy.Adversitement.Common;
using Udemy.Adversitement.Common.Interfaces;
using Udemy.Advertisement.Entities;
using Udemy.AdvertisementApp.Dtos.Interfaces;

namespace Udemy.AdvertisementApp.Bussines.Interfaces
{
    public interface IService<CreateDto,UpdateDto,ListDto,T> where CreateDto : class, ICreateDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IListDto, new()
        where T : BaseEntity
        
    {
        Task<IResponse<CreateDto>> CreateAsync(CreateDto model);

        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto model);

        Task<IResponse<IDtoo>> GetByIdAsync<IDtoo>(int id) where IDtoo : class, IDto, new();

        Task<IResponse> RemoveAsync(int id);

        Task<Response<List<ListDto>>> GetAllAsync();

        Task<Response<List<ListDto>>> GetAllAsync(Expression<Func<ListDto, bool>> filter);

    }
}
