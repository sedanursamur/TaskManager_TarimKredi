using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskManager.TaskTrackingApp.Bussines.Dependency_Resolvers.Microsoft;
using TaskManager.TaskTrackingApp.Bussines.Services;
using TaskManager.TaskTrackingApp.DataAccess.Context;
using TaskManager.TaskTrackingApp.Dtos;
using TaskManager.TaskTrackingApp.Entities;
using TaskManager.TaskTrackingApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.TaskTrackingApp.Bussines.Interfaces;

namespace TaskManager.TaskTrackingApp.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddNewtonsoftJson(setup => setup.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            var profiles = services.DependencyExtension();// dependency Inversion d�n��tipi profil dizisi olarak ayarl�

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(opt =>
            {
                opt.LoginPath = "/Account/Login";
                opt.Cookie.Name = "TaskTrackingIdentityCookie";
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(1);
                opt.Cookie.SameSite = SameSiteMode.Strict;
            });
            //services.AddIdentity<AppUser, IdentityRole>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(profiles);
                cfg.CreateMap<AppTaskCreateDto, AppTaskCreateModel>().ReverseMap();
                cfg.CreateMap<AppTaskListDto, AppTaskUpdateModel>().ReverseMap();
                cfg.CreateMap<AppTaskUpdateDto, AppTaskUpdateModel>().ReverseMap();
                cfg.CreateMap<AppUserCreateDto, AppUserCreateModel>().ReverseMap();
            }
);
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<AppUserRoleService>();
       

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppUserRoleService _userRoleService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            Task.Run(async () => await _userRoleService.AddRolesToDatabase()).Wait();
            Task.Run(async () => await _userRoleService.CreateAdminUser()).Wait();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}