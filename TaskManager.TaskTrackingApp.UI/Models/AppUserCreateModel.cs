using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManager.TaskTrackingApp.Dtos;

namespace TaskManager.TaskTrackingApp.UI.Models
{
    public class AppUserCreateModel : AppUserCreateDto
    {
        public SelectList DegreeSelectList { get; set; }
    }
}
