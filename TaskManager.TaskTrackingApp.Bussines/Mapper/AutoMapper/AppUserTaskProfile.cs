using AutoMapper;
using TaskManager.TaskTrackingApp.Dtos.AppUserTaskDtos;
using TaskManager.TaskTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Bussines.Mapper.AutoMapper
{
    public class AppUserTaskProfile : Profile
    {
        public AppUserTaskProfile()
        {
            CreateMap<AppUserTask, AppUserTaskCreateDto>().ReverseMap();
            CreateMap<AppUserTask, AppUserTaskListDto>().ReverseMap();
            CreateMap<AppUserTask, AppUserTaskUpdateDto>().ReverseMap();
            CreateMap<AppUserTaskListDto, AppUserTaskUpdateDto>().ReverseMap();
        }
    }
}
