using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.TaskTrackingApp.Bussines.FluentValidation.AppTask;
using TaskManager.TaskTrackingApp.Bussines.FluentValidation.AppUser;
using TaskManager.TaskTrackingApp.Bussines.FluentValidation.AppUserRole;
using TaskManager.TaskTrackingApp.Bussines.FluentValidation.AppUserTask;
using TaskManager.TaskTrackingApp.Bussines.Interfaces;
using TaskManager.TaskTrackingApp.Bussines.Mapper.AutoMapper;
using TaskManager.TaskTrackingApp.Bussines.Mapper.AutoMapper.AppUserMapper;
using TaskManager.TaskTrackingApp.Bussines.Services;
using TaskManager.TaskTrackingApp.DataAccess.Context;
using TaskManager.TaskTrackingApp.DataAccess.Interfaces;
using TaskManager.TaskTrackingApp.DataAccess.UnitOfWork;
using TaskManager.TaskTrackingApp.Dtos;
using TaskManager.TaskTrackingApp.Dtos.AppUserRoleDtos;
using TaskManager.TaskTrackingApp.Dtos.AppUserTaskDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Bussines.Dependency_Resolvers.Microsoft
{
    public static class DependencyInversion
    {
        public static List<Profile> DependencyExtension(this IServiceCollection services)
        {
            services.AddDbContext<TaskTrackingContext>();

            services.AddScoped<IUow, Uow>();
            var profiles = new List<Profile>() {
                new AppUserProfile(),
                new AppRoleProfile(),
                new AppTaskProfile(),
                new AppUserRoleProfile(),
                new AppUserTaskProfile()
            };


            services.AddScoped<IValidator<AppUserCreateDto>, AppUserCreateValidator>();
            services.AddScoped<IValidator<AppUserTaskCreateDto>, AppUserTaskCreateDtoValidator>();
            services.AddScoped<IValidator<AppUserTaskUpdateDto>, AppUserTaskUpdateDtoValidator>();
            services.AddScoped<IValidator<AppTaskCreateDto>, AppTaskCreateDtoValidator>();
            services.AddScoped<IValidator<AppUserRoleCreateDto>, AppUserRoleCreateDtoValidator>();

            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAppTaskService, AppTaskService>();
            services.AddScoped<IAppUserRoleService, AppUserRoleService>();
            services.AddScoped<IAppUserTaskService, AppUserTaskService>();

            return profiles;
        }
    }
}