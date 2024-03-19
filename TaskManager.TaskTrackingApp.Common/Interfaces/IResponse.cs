using TaskManager.TaskTrackingApp.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Common.Interfaces
{
    public interface IResponse
    {
        public string Message { get; set; }

        public ResponseType ResponseType { get; set; }
    }
}
