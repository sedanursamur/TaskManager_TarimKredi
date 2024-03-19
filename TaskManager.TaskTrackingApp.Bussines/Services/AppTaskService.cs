using AutoMapper;
using FluentValidation;
using TaskManager.TaskTrackingApp.Bussines.Interfaces;
using TaskManager.TaskTrackingApp.Common.Enums;
using TaskManager.TaskTrackingApp.Common;
using TaskManager.TaskTrackingApp.Common.Interfaces;
using TaskManager.TaskTrackingApp.DataAccess.Interfaces;
using TaskManager.TaskTrackingApp.DataAccess.UnitOfWork;
using TaskManager.TaskTrackingApp.Dtos;
using TaskManager.TaskTrackingApp.Dtos.PriortryDtos;
using TaskManager.TaskTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.TaskTrackingApp.Dtos.Interfaces;

namespace TaskManager.TaskTrackingApp.Bussines.Services
{
    public class AppTaskService : Service<AppTaskCreateDto,AppTaskUpdateDto,AppTaskListDto,AppTask> , IAppTaskService 
    {
        readonly IUow _uow;
        readonly IMapper _mapper;
        public AppTaskService(IUow uow, IMapper mapper, IValidator<AppTaskCreateDto> validator) : base(uow, mapper, validator)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public Task<IResponse<AppTaskListDto>> GetIncluded(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResponse<List<AppTaskListDto>>> GetIncluded()
        {

            return new Response<List<AppTaskListDto>>(ResponseType.Success,_mapper.Map<List<AppTaskListDto>>(_uow.GetRepository<AppTask>().GetQueryable().Include(x => x.Priortry).ToList()));
        }

        public async Task<IResponse<List<PriortryListDto>>> GetPriortiries()
        {
            // Veritabanında enum değerlerinin varlığını kontrol edelim
            var existingPriorities = await _uow.GetRepository<Priortry>().GetAllAsync();

            if (existingPriorities.Count == 0)
            {
                // Enum değerleri veritabanında henüz eklenmemiş, ekleme işlemini yapalım
                var priorities = Enum.GetValues(typeof(PriortryType)).Cast<PriortryType>().ToList();

                foreach (var priority in priorities)
                {
                    await _uow.GetRepository<Priortry>().CreateAsync(new Priortry
                    {
                        Defination = priority.ToString()
                    });
                }

                await _uow.SaveChangesAsync();
            }

            // Enum verilerini veritabanından alıyorum
      
            var priorityListDto = _mapper.Map<List<PriortryListDto>>(existingPriorities);

            return new Response<List<PriortryListDto>>(ResponseType.Success, priorityListDto);
        }

        public async Task<IResponse<IList<AppUserListDto>>> GetUser()
        {
            
                var existingUsers = await _uow.GetRepository<AppUser>().GetAllAsync();
                var userListDto = _mapper.Map<List<AppUserListDto>>(existingUsers);

                return new Response<IList<AppUserListDto>>(ResponseType.Success, userListDto);
            
        
        }



    }
}
