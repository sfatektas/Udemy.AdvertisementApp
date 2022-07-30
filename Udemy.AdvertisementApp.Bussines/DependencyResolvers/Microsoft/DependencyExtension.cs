using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Udemy.AdvertisementApp.Bussines.AutoMapper;
using Udemy.AdvertisementApp.Bussines.Interfaces;
using Udemy.AdvertisementApp.Bussines.Services;
using Udemy.AdvertisementApp.Bussines.ValidationRules.AppUserRules;
using Udemy.AdvertisementApp.Bussines.ValidationRules.ProvidedServiceRules;
using Udemy.AdvertisementApp.DataAccess.Contexts;
using Udemy.AdvertisementApp.DataAccess.Interfaces;
using Udemy.AdvertisementApp.DataAccess.UnitOfWorks;
using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.Dtos.AppUserDtos;
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
            var mapperConfiguration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new AppUserProfile());
                opt.AddProfile(new ProvidedServiceProfile());
            });
            var mapper = mapperConfiguration.CreateMapper();

            //Singleton olarak instance yaratırsak mapper olarak bir problem arz etmiyor.
            services.AddSingleton(mapper);

            services.AddScoped<IUow,Uow>();
            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();

            //Generic serviste Dı geçmek yerine AppUserService üzerinde DI geçiyoruz.
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IProvidedServiceService, ProvidedServiceService>();
        }
    }
}
