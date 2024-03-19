using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Entities
{
    public class Degree : BaseEntity
    {
        public string Defination { get; set; }

        public List<AppUser> AppUsers { get; set; }
    }
}
