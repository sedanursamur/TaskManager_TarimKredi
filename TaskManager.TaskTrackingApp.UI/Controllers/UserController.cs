using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.TaskTrackingApp.Bussines.Interfaces;
using TaskManager.TaskTrackingApp.Common.Enums;
using TaskManager.TaskTrackingApp.DataAccess.Interfaces;
using TaskManager.TaskTrackingApp.Dtos;
using TaskManager.TaskTrackingApp.Dtos.AppUserTaskDtos;
using TaskManager.TaskTrackingApp.UI.Helper;
using TaskManager.TaskTrackingApp.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.UI.Controllers
{
    //[Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAppUserTaskService _appUserTaskService;
        private readonly IAppTaskService _appTaskService;

        public UserController(IAppUserTaskService appUserTaskService, IAppTaskService appTaskService, IMapper mapper)
        {
            _appUserTaskService = appUserTaskService;
            _appTaskService = appTaskService;
            _mapper = mapper;
        }

        public IActionResult TakeTask()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AcceptTask(int taskId, string userName)
        {
            var taskResponse = await _appTaskService.GetByIdAsync(taskId);
            var result = await _appUserTaskService.CreateAppUserTask(taskId, userName);
            if (result.ResponseType == ResponseType.Success)
            {
                taskResponse.Data.IsActive = false;// Görevi pasif hale getiriyoruz.
                await _appTaskService.UpdateAsync(_mapper.Map<AppTaskUpdateDto>(taskResponse.Data));
            }
            return RedirectToAction("MyTasks");
        }
        public IActionResult MyTasks()
        {
            return View();
        }
        [Route("User/TaskDetail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var response = await _appUserTaskService.GetIncluded(id);
            return View(_mapper.Map<AppUserTaskListDto>(response.Data));
        }
        [HttpGet]
        public async Task<IActionResult> ComplateTask(int id)
        {
            // to do queryable yapıp defination propertyleri doldur , jquery çalışıyor mu kontrol et 
            var response = await _appUserTaskService.GetIncluded(id);
            if (response.ResponseType == ResponseType.Success)
            {
                return View(_mapper.Map<AppUserTaskUpdateDto>(response.Data));
            }
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> ComplateTask(AppUserTaskUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _appUserTaskService.GetByIdAsync(model.AppUserTaskId);
                if (response.ResponseType == ResponseType.Success)
                {
                    var data = response.Data;
                    data.CompleteDocumentDefination = model.CompleteDocumentDefination;
                    data.CompletedTaskDate = DateTime.Now;
                    data.TaskStatusId = (int)TaskStatusType.Tamamlandı;
                    // if file exist
                    var path = model.TaskComplateFile == null ? "Boş" : HelperMethods.CreateGuidWithExtension(model.TaskComplateFile.FileName);

                    data.DocumentPath = path;

                    var updateResponse = await _appUserTaskService.UpdateAsync(_mapper.Map<AppUserTaskUpdateDto>(data));
                    if (updateResponse.ResponseType == ResponseType.Success)
                    {
                        try
                        {
                            if (model.TaskComplateFile != null)
                            {
                                using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", path)/*$"~/Files/{filePath}"*/, FileMode.Create))
                                {
                                    await model.TaskComplateFile.CopyToAsync(stream);
                                }
                            }
                            return RedirectToAction("MyTasks");
                        }
                        catch (Exception e)
                        {
                            ViewBag.Message = $"Dosya kaydedilirken bir sorun oluştu. Hata mesajı : {e.Message}";
                            return View(model);
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Bir sorun oluştu";
                        return View(model);
                    }

                }
                else
                {
                    ViewBag.Message = response.Message;
                    return View(model);
                }
            }
            return View(model);
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
