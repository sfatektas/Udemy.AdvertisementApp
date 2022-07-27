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
using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.Dtos.AppUserDtos;
using Udemy.AdvertisementApp.Dtos.Interfaces;

namespace Udemy.AdvertisementApp.Bussines.Services
{
    public class Service<CreateDto, UpdateDto, ListDto, T> : IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class,ICreateDto, new()
        where UpdateDto : class,IUpdateDto, new()
        where ListDto : class,IDto, new()
        where T : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createDtoValidator;
        private readonly IValidator<UpdateDto> _updateDtoValidator;
        private readonly IUow _uow;

        public Service(IMapper mapper, IValidator<CreateDto> createDtoValidator, IValidator<UpdateDto> updateDtoValidator, IUow uow)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _uow = uow;
        }

        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto model)
        {
            var result = await _createDtoValidator.ValidateAsync(model);
            if (result.IsValid)
            {
                await _uow.GetRepository<T>().CreateAsync(_mapper.Map<T>(model));
                return new Response<CreateDto>(ResponseType.Success, model);
            }
            //validation extension
            return new Response<CreateDto>(ResponseType.ValidationError, model, result.ConvertToErrorList());

        }
        public async Task<Response<List<ListDto>>> GetAllAsync()
        {
            var TList = await _uow.GetRepository<T>().GetAllAsync();
            return new Response<List<ListDto>>(ResponseType.Success,_mapper.Map<List<ListDto>>(TList));
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            var data = await _uow.GetRepository<T>().FindAsync(id);
            if(data != null)
            {
                 _uow.GetRepository<T>().Remove(data);
                return new Response(ResponseType.Success);
            }
            return new Response("İlgili veri bulunamadı.",ResponseType.NotFound);
        }

        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto model)
        {
        
            var unchanged = await _uow.GetRepository<T>().FindAsync(model.Id);
            if (unchanged == null)
            {
                _uow.GetRepository<T>().Update(_mapper.Map<T>(model), unchanged);
                return new Response<UpdateDto>("İlgili data bulunamadı.",ResponseType.NotFound);
            }
            return new Response<UpdateDto>(ResponseType.Success,model);

        }

        public async Task<IResponse<IDtoo>> GetByIdAsync<IDtoo>(int id) where IDtoo : class, IDto, new()
        {
            var data = await _uow.GetRepository<T>().GetByFilterAsync(x => x.Id == id);
            if (data != null)
            {
                return new Response<IDtoo>(ResponseType.Success, _mapper.Map<IDtoo>(data));
            }
            return new Response<IDtoo>("Böyle bir kayıta ulaşılamadı.", ResponseType.NotFound);
        }

    }
}
