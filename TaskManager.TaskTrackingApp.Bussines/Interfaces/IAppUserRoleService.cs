using TaskManager.TaskTrackingApp.Common.Interfaces;
using TaskManager.TaskTrackingApp.Dtos;
using TaskManager.TaskTrackingApp.Dtos.AppUserRoleDtos;
using TaskManager.TaskTrackingApp.Dtos.DegreeDtos;
using TaskManager.TaskTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Bussines.Interfaces
{
    public interface IAppUserRoleService : IService<AppUserRoleCreateDto, AppUserRoleUpdateDto, AppUserRoleListDto, AppUserRole>
    {

        Task AddRolesToDatabase();
        Task CreateAdminUser();


    }
}
