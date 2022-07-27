using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Udemy.AdvertisementApp.Bussines.ValidationRules.AppUserRules;
using Udemy.AdvertisementApp.DataAccess.Contexts;
using Udemy.AdvertisementApp.DataAccess.Interfaces;
using Udemy.AdvertisementApp.DataAccess.UnitOfWorks;
using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.Dtos.AppUserDtos;

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
                //opt.AddProfile();
            });
            var mapper = mapperConfiguration.CreateMapper();
            services.AddScoped<IUow,Uow>();
            services.AddScoped<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddScoped<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
        }
    }
}
