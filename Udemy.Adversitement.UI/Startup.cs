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
using Udemy.AdvertisementApp.Bussines;

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
            services.AddControllersWithViews();
            //DependencyResolves i�erisinde tan�mlanan dbconnect propertysinin useSql methodu burda 
            //ge�ildi
            services.DependencyInjection(Configuration);
            //Configuration.GetConnectionString("Local");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World");
                });
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
