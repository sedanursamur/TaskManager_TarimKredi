using FluentValidation;
using TaskManager.TaskTrackingApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Bussines.FluentValidation.AppTask
{
    class AppTaskCreateDtoValidator : AbstractValidator<AppTaskCreateDto>
    {
        public AppTaskCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Defination).NotEmpty();
            RuleFor(x => x.PriortryId).NotEmpty();
            RuleFor(x => x.AppUserId).NotEmpty();
            RuleFor(x => x.EndDateTime).NotEmpty();
        }
    }
}
