using AutoMapper;
using TaskManager.TaskTrackingApp.Dtos.AppUserRoleDtos;
using TaskManager.TaskTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Bussines.Mapper.AutoMapper
{
    public class AppUserRoleProfile : Profile
    {
        public AppUserRoleProfile()
        {
            CreateMap<AppUserRole, AppUserRoleCreateDto>().ReverseMap();
            CreateMap<AppUserRole, AppUserRoleListDto>().ReverseMap();
            CreateMap<AppUserRole, AppUserRoleUpdateDto>().ReverseMap();
        }
    }
}
