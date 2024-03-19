using FluentValidation;
using TaskManager.TaskTrackingApp.Dtos.AppUserRoleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Bussines.FluentValidation.AppUserRole
{
    public class AppUserRoleCreateDtoValidator : AbstractValidator<AppUserRoleCreateDto>
    {
        public AppUserRoleCreateDtoValidator()
        {
            RuleFor(x => x.AppRoleId).NotEmpty();
            RuleFor(x => x.AppUserId).NotEmpty();
        }
    }
}
