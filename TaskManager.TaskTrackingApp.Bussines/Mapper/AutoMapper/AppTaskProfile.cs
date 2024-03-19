using AutoMapper;
using TaskManager.TaskTrackingApp.Dtos;
using TaskManager.TaskTrackingApp.Dtos.PriortryDtos;
using TaskManager.TaskTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Bussines.Mapper.AutoMapper
{
    public class AppTaskProfile : Profile
    {
        public AppTaskProfile()
        {
            CreateMap<AppTask, AppTaskListDto>().ReverseMap();
            CreateMap<AppTaskUpdateDto, AppTaskListDto>().ReverseMap();
            CreateMap<AppTask, AppTaskUpdateDto>().ReverseMap();
            CreateMap<AppTask, AppTaskCreateDto>().ReverseMap();
            //AppTaskStatus
            CreateMap<AppTaskStatus, AppTaskStatusListDto>().ReverseMap();
            //Priortry
            CreateMap<Priortry, PriortryListDto>().ReverseMap();
        }
    }
}
