using TaskManager.TaskTrackingApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Dtos.AppUserTaskDtos
{
    public class AppUserTaskListDto : IListDto
    {
        public int Id { get; set; }
        
        public int AppUserId { get; set; }

        public AppUserListDto AppUser { get; set; }

        public int AppTaskId { get; set; }

        public AppTaskListDto AppTask { get; set; }

        public int TaskStatusId { get; set; }

        public AppTaskStatusListDto TaskStatus { get; set; }

        public DateTime TaskEndDate { get; set; }


        public DateTime? CompletedTaskDate { get; set; }

        public string CompleteDocumentDefination { get; set; }

        public string DocumentPath { get; set; }
    }
}
