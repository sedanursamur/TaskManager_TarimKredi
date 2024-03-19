using AutoMapper;
using TaskManager.TaskTrackingApp.Dtos;
using TaskManager.TaskTrackingApp.Dtos.DegreeDtos;
using TaskManager.TaskTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Bussines.Mapper.AutoMapper.AppUserMapper
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, AppUserListDto>().ReverseMap();
            CreateMap<AppUser, AppUserCreateDto>().ReverseMap();
            CreateMap<AppUser, AppUserUpdateDto>().ReverseMap();
            //Degreee
            CreateMap<Degree, DegreeListDto>().ReverseMap();
        }
    }
}
