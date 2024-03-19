using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Dtos.Interfaces
{
    public interface IListDto : IDto
    {
        public int Id { get; set; }
    }
}
