using TaskManager.TaskTrackingApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Dtos.AppUserTaskDtos
{
    public class AppUserTaskCreateDto : ICreateDto
    {
        public int AppUserId { get; set; }

        public int AppTaskId { get; set; }

        public int TaskStatusId { get; set; }

        public DateTime TaskEndDate { get; set; }
    }
}
