using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Udemy.AdvertisementApp.DataAccess.Contexts;

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
        }
    }
}
