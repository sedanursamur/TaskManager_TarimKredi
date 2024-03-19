using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Entities
{
    public class AppTask : BaseEntity
    {
        public string Title { get; set; }

        public string  Defination { get; set; }

        public int PriortryId { get; set; }
        public int AppUserId { get; set; }

        public Priortry Priortry { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public AppUserTask AppUserTask { get; set; }

        public bool IsActive { get; set; }
    }
}
