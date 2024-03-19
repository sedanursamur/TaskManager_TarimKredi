using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Common.Interfaces
{
    public interface IResponse<T> : IResponse
    {
        public T Data { get; set; }

        public List<CustomValidationError> ValidationErrors { get; set; }
    }
}
