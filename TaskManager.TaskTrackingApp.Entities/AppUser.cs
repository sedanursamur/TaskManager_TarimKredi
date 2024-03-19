using System;
using System.Collections.Generic;

namespace TaskManager.TaskTrackingApp.Entities
{
    public class AppUser : BaseEntity
    {
        public string FirstName { get; set; }

        public string  LastName { get; set; }

        public string Username { get; set; }

        public string  Email { get; set; }

        public int DegreeId { get; set; } //Ünvan

        public Degree Degree { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
