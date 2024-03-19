using Microsoft.AspNetCore.Mvc;

namespace TaskManager.TaskTrackingApp.UI.ViewComponents
{
    public class UserAddComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
