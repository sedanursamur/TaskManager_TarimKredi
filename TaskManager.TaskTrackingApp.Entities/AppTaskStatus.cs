using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Entities
{
    public class AppTaskStatus : BaseEntity
    {
        public string  Defination { get; set; }

        public List<AppUserTask> AppUserTasks { get; set; }
    }
}
