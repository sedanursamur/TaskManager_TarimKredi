using TaskManager.TaskTrackingApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Dtos.AppRoleDtos
{
    public class AppRoleCreateDto : ICreateDto
    {
        public string Defination { get; set; }
    }
}
