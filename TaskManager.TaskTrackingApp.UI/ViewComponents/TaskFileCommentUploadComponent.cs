using Microsoft.AspNetCore.Mvc;
using TaskManager.TaskTrackingApp.UI.Models;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.UI.ViewComponents
{
    public class TaskFileCommentUploadComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            return View(new AppUserTaskUpdateModel() { AppUserTaskId = id});
        }
    }
}
