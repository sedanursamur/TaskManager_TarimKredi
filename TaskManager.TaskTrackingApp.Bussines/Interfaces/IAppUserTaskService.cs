using TaskManager.TaskTrackingApp.Common.Interfaces;
using TaskManager.TaskTrackingApp.Dtos;
using TaskManager.TaskTrackingApp.Dtos.AppUserTaskDtos;
using TaskManager.TaskTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Bussines.Interfaces
{
    public interface IAppUserTaskService : IService<AppUserTaskCreateDto,AppUserTaskUpdateDto,AppUserTaskListDto,AppUserTask>, IIncludeable<AppUserTaskListDto>
    {
        Task<IResponse> CreateAppUserTask(int taskId, string userName);
        Task<IResponse<List<AppUserTaskListDto>>> GetTasksWithUserId(int id);
    }
}
