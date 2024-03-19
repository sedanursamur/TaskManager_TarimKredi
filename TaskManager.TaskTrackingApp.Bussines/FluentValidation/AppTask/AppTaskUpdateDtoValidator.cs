using FluentValidation;
using TaskManager.TaskTrackingApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Bussines.FluentValidation.AppTask
{
    public class AppTaskUpdateDtoValidator : AbstractValidator<AppTaskCreateDto>
    {
        public AppTaskUpdateDtoValidator()
        {
            RuleFor(x => x.Defination).NotNull();
            RuleFor(x => x.Title).NotNull();
            RuleFor(x => x.PriortryId).NotNull();
            RuleFor(x => x.AppUserId).NotNull();
            RuleFor(x => x.EndDateTime).NotNull();
        }
    }
}
