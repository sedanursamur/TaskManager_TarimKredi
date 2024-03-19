using FluentValidation;
using TaskManager.TaskTrackingApp.Dtos.AppUserTaskDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Bussines.FluentValidation.AppUserTask
{
    public class AppUserTaskUpdateDtoValidator : AbstractValidator<AppUserTaskUpdateDto>
    {
        public AppUserTaskUpdateDtoValidator()
        {
            RuleFor(x => x.AppUserId).NotNull();
            RuleFor(x => x.AppTaskId).NotNull();
            RuleFor(x => x.TaskStatusId).NotNull();
            RuleFor(x => x.CompleteDocumentDefination).NotNull();
        }
    }
}
