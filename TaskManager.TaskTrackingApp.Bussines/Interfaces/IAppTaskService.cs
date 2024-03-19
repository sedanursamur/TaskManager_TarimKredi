using TaskManager.TaskTrackingApp.Common.Interfaces;
using TaskManager.TaskTrackingApp.Dtos;
using TaskManager.TaskTrackingApp.Dtos.PriortryDtos;
using TaskManager.TaskTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Bussines.Interfaces
{
    public interface IAppTaskService : IService<AppTaskCreateDto, AppTaskUpdateDto, AppTaskListDto, AppTask> , IIncludeable<AppTaskListDto>
    {
        Task<IResponse<List<PriortryListDto>>> GetPriortiries();
        Task<IResponse<IList<AppUserListDto>>> GetUser();
    }
}
