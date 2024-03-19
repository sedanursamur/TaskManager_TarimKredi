using TaskManager.TaskTrackingApp.Dtos.AppUserRoleDtos;
using TaskManager.TaskTrackingApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Dtos
{
    public class AppUserUpdateDto : IUpdateDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public int DegreeId { get; set; } //Ünvan

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public List<AppUserRoleListDto> AppUserRoles { get; set; }

    }
}
