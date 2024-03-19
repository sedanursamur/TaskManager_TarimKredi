using Microsoft.AspNetCore.Mvc;
using TaskManager.TaskTrackingApp.Bussines.Interfaces;
using TaskManager.TaskTrackingApp.Common.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.UI.ViewComponents
{
    public class UserTasksComponent : ViewComponent
    {
        readonly IAppUserTaskService _appUserTaskService;

        public UserTasksComponent(IAppUserTaskService appUserTaskService)
        {
            _appUserTaskService = appUserTaskService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var response = await _appUserTaskService.GetIncluded();
            if (response.ResponseType == ResponseType.Success)
            {
                return View(response.Data.Where(x=>x.AppUserId==id).OrderBy(x=>x.TaskStatusId).ToList());
            }
            return View();
        }
    }
}
