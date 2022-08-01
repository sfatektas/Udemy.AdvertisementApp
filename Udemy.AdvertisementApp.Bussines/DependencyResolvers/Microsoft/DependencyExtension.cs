using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Udemy.AdvertisementApp.Bussines.AutoMapper;
using Udemy.AdvertisementApp.Bussines.Interfaces;
using Udemy.AdvertisementApp.Bussines.Services;
using Udemy.AdvertisementApp.Bussines.ValidationRules.AdvertisementRules;
using Udemy.AdvertisementApp.Bussines.ValidationRules.AppUserRules;
using Udemy.AdvertisementApp.Bussines.ValidationRules.GenderRules;
using Udemy.AdvertisementApp.Bussines.ValidationRules.ProvidedServiceRules;
using Udemy.AdvertisementApp.DataAccess.Contexts;
using Udemy.AdvertisementApp.DataAccess.Interfaces;
using Udemy.AdvertisementApp.DataAccess.UnitOfWorks;
using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.Dtos.AdversitementDtos;
using Udemy.AdvertisementApp.Dtos.AppUserDtos;
using Udemy.AdvertisementApp.Dtos.GenderDtos;
using Udemy.AdvertisementApp.Dtos.ProvidedServicesDtos;

namespace Udemy.AdvertisementApp.Bussines
{
    public static class DependencyExtension
    {
        public static void DependencyInjection(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });
           

            services.AddScoped<IUow,Uow>();
            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();

            //Generic serviste Dı geçmek yerine AppUserService üzerinde DI geçiyoruz.
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IProvidedServiceService, ProvidedServiceService>();
            services.AddScoped<IAdvertisementService, AdvertisementServices>();
            services.AddScoped<IGenderService, GenderService>();
        }
        //Mapper configurasyonları burda geçmek yerine sadece Profilleri burda ekleyip döndüren extra bir helper klasörü altında method yazıp startup 
        //tarafında usermodelcreate gibi modelleri mapper configurasyonuna eklemek için DI 'yı orda geçeceğiz. 
    }
}
