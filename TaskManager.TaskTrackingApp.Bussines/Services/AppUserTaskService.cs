using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TaskManager.TaskTrackingApp.Bussines.Interfaces;
using TaskManager.TaskTrackingApp.Common;
using TaskManager.TaskTrackingApp.Common.Enums;
using TaskManager.TaskTrackingApp.Common.Interfaces;
using TaskManager.TaskTrackingApp.DataAccess.Interfaces;
using TaskManager.TaskTrackingApp.Dtos;
using TaskManager.TaskTrackingApp.Dtos.AppUserTaskDtos;
using TaskManager.TaskTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Bussines.Services
{
    public class AppUserTaskService: Service<AppUserTaskCreateDto,AppUserTaskUpdateDto , AppUserTaskListDto, AppUserTask> ,IAppUserTaskService
    {
        readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IAppUserService _appUserService;
        private readonly IAppTaskService _appTaskService;
        readonly IValidator<AppUserTaskCreateDto> _validator;

        public AppUserTaskService(IUow uow, IAppUserService appUserService, IAppTaskService appTaskService, IMapper mapper,IValidator<AppUserTaskCreateDto> validator):base(uow,mapper,validator)
        {
            _uow = uow;
            _appUserService = appUserService;
            _appTaskService = appTaskService;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<IResponse> CreateAppUserTask(int taskId,string userName)
        {
            var userResponse = await _appUserService.GetByFilterUser(x => x.Username == userName);
            var taskResponse = await _appTaskService.GetByIdAsync(taskId);

            //task statuslerin db ye kayıt edildiği yer
            var taskStatuses = await _uow.GetRepository<AppTaskStatus>().GetAllAsync();

            if (taskStatuses.Count == 0)
            {
                
                var statuses = Enum.GetValues(typeof(PriortryType)).Cast<TaskStatusType>().ToList();

                foreach (var status in statuses)
                {
                    await _uow.GetRepository<AppTaskStatus>().CreateAsync(new AppTaskStatus
                    {
                        Defination = status.ToString()
                    });
                }

                await _uow.SaveChangesAsync();
            }

            await _uow.GetRepository<AppUserTask>().CreateAsync(new AppUserTask
            {
                AppTaskId = taskId,
                AppUserId = userResponse.Data.Id,
                TaskEndDate =taskResponse.Data.EndDateTime,
                TaskStatusId = (int)TaskStatusType.GorevAlındı,
            });
            await _uow.SaveChangesAsync();
            return new Response(ResponseType.Success);
        }

        public async Task<IResponse<AppUserTaskListDto>> GetIncluded(int id)
        {
            return new Response<AppUserTaskListDto>(ResponseType.Success, _mapper.Map<AppUserTaskListDto>(await _uow.GetRepository<AppUserTask>().GetQueryable(id).Include(x => x.AppTask).ThenInclude(x => x.Priortry).Include(x => x.AppUser).Include(x => x.TaskStatus).SingleOrDefaultAsync()));
        }

        public async Task<IResponse<List<AppUserTaskListDto>>> GetIncluded()
        {
            return new Response<List<AppUserTaskListDto>>(ResponseType.Success, _mapper.Map<List<AppUserTaskListDto>>(await _uow.GetRepository<AppUserTask>().GetQueryable().Include(x => x.AppTask).ThenInclude(x=>x.Priortry).Include(x=>x.AppUser).Include(x=>x.TaskStatus).ToListAsync()));
        }

        public async Task<IResponse<List<AppUserTaskListDto>>> GetTasksWithUserId(int id)
        {
        
            var data = _uow.GetRepository<AppUserTask>().GetQueryable();
            await data.Include(x => x.AppUser).Include(x => x.AppTask).ThenInclude(x=>x.Priortry).Include(x => x.TaskStatus).OrderByDescending(x=>x.TaskStatusId).ToListAsync();
            if (data == null)
                return new Response<List<AppUserTaskListDto>>(ResponseType.NotFound,"Veri Bulunamadı.",new List<AppUserTaskListDto>());
            return new Response<List<AppUserTaskListDto>>(ResponseType.Success, _mapper.Map<List<AppUserTaskListDto>>(data));
        }
    }
}
