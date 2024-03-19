using FluentValidation;
using TaskManager.TaskTrackingApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Bussines.FluentValidation.AppUser
{
    public class AppUserCreateValidator : AbstractValidator<AppUserCreateDto>
    {
        public AppUserCreateValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DegreeId).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().NotNull();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
