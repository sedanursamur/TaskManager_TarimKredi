using TaskManager.TaskTrackingApp.Common.Interfaces;
using TaskManager.TaskTrackingApp.Dtos;
using TaskManager.TaskTrackingApp.Dtos.AppRoleDtos;
using TaskManager.TaskTrackingApp.Dtos.DegreeDtos;
using TaskManager.TaskTrackingApp.Dtos.PriortryDtos;
using TaskManager.TaskTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Bussines.Interfaces
{
    public interface IAppUserService : IService<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser>, IIncludeable<AppUserListDto>
    {
        Task<IResponse<AppUserListDto>> GetByFilterUser(Expression<Func<AppUser, bool>> filter);
        Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsync(int userId);
        Task<IResponse<List<DegreeListDto>>> GetDegrees();
      
    }
}
