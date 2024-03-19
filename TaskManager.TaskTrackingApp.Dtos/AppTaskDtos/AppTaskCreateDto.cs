using TaskManager.TaskTrackingApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Dtos
{
    public class AppTaskCreateDto : ICreateDto
    {
        public string Title { get; set; }

        public string Defination { get; set; }

        public int PriortryId { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public bool IsActive { get; set; }
        public int AppUserId { get; set; }
    }
}
