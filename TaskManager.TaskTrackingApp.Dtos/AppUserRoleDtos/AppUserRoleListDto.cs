using TaskManager.TaskTrackingApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Dtos.AppUserRoleDtos
{
    public class AppUserRoleListDto : IListDto
    {
        public int Id { get; set; }

        public int AppUserId { get; set; }

        public int AppRoleId { get; set; }
    }
}
