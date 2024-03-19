using TaskManager.TaskTrackingApp.Common.Enums;
using TaskManager.TaskTrackingApp.Common.Interfaces;
using TaskManager.TaskTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Common
{
    public class Response<T> : Response, IResponse<T> where T : class
    {
        public T Data { get; set; }

        public List<CustomValidationError> ValidationErrors { get; set; }

        public Response(ResponseType responseType, T data) : base(responseType)
        {
            Data = data;
        }
        public Response(ResponseType responseType, string message, T data) : base(responseType, message)
        {
            Data = data;
        }
        public Response(ResponseType responseType,T data,List<CustomValidationError> validationErrors) : base(responseType)
        {
            Data = data;
            ValidationErrors = validationErrors;
        }

    }
}
