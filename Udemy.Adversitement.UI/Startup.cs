using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy.Adversitement.UI.Mapper.AutoMapper;
using Udemy.Adversitement.UI.Models;
using Udemy.Adversitement.UI.ValidationRules;
using Udemy.AdvertisementApp.Bussines;
using Udemy.AdvertisementApp.Bussines.Helpers;

//N-tier ; 
// UI , DTOS , BAL , ENTities , DAL , Common(Response , validation errors)
// EF core design paketi UI taraf�na kurulur.
namespace Udemy.Adversitement.UI
{
    public class Startup
    {
        //net core frameworku i�erisinde default olarak bu property DI ge�ilir.
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //Configuration.GetConnectionString("Local");
            services.DependencyInjection(Configuration);

            services.AddControllersWithViews();
            //DependencyResolves i�erisinde tan�mlanan dbconnect propertysinin useSql methodu burda 
            //ge�ildi
            var profiles = ProfileHelper.GetProfiles();
            profiles.Add(new UserCreateModelProfile());
            var mapperConfiguration = new MapperConfiguration(opt =>
            {
                //Busines taraf�ndaki profilleri d�nd�r�p UI katman�ndaki profilide ekliyoruz. Daha sonra DI ge�iyoruz.
                opt.AddProfiles(profiles);
            });
            var mapper = mapperConfiguration.CreateMapper();

            //Singleton olarak instance yarat�rsak mapper olarak bir problem arz etmiyor.
            services.AddSingleton(mapper);

            services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
