using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Entities
{
    public class AppUserTask : BaseEntity
    {
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public int AppTaskId { get; set; }

        public AppTask AppTask { get; set; }

        public int TaskStatusId { get; set; }

        public AppTaskStatus TaskStatus { get; set; }

        public DateTime TaskEndDate { get; set; }

        //Complated

        public DateTime? CompletedTaskDate { get; set; } 

        public string CompleteDocumentDefination { get; set; } 

        public string DocumentPath { get; set; } = String.Empty;
    }
}
