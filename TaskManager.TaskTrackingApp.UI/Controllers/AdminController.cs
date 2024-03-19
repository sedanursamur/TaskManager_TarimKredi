using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManager.TaskTrackingApp.Bussines.Interfaces;
using TaskManager.TaskTrackingApp.Common.Enums;
using TaskManager.TaskTrackingApp.Dtos;
using TaskManager.TaskTrackingApp.Entities;
using TaskManager.TaskTrackingApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        readonly IAppUserService _appUserService;
        readonly IAppUserTaskService _appUserTaskService;
        readonly IAppTaskService _appTaskService;
        readonly IAppUserRoleService _appUserRoleService;
        readonly IMapper _mapper; // for model to dto 
        public AdminController(IAppUserService appUserService, IAppUserTaskService appUserTaskService, IAppTaskService appTaskService, IMapper mapper, IAppUserRoleService appUserRoleService)
        {
            _appUserService = appUserService;
            _appUserTaskService = appUserTaskService;
            _appTaskService = appTaskService;
            _mapper = mapper;
            _appUserRoleService = appUserRoleService;
        }
        [HttpGet]
        public async Task<IActionResult> UserManagment()
        {
            var response = await _appUserService.GetIncluded();
            if (response.ResponseType == ResponseType.Success)
            {
                return View(response.Data.Where(x => x.AppUserRoles.All(x => x.AppRoleId == (int)RoleType.User)&& x.IsActive ==true).ToList());
            }
            ViewBag.Message = "İlgili Data Bulunamadı.";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            var responseDegrees = await _appUserService.GetDegrees();
            if (responseDegrees.ResponseType == ResponseType.Success)
            {
                var model = new AppUserCreateModel();
                model.DegreeSelectList = new SelectList(responseDegrees.Data, "Id", "Defination");
                return View(model);
            }
            ViewBag.Message = responseDegrees.Message;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(AppUserCreateModel model)
        {
            model.Password = model.FirstName;// default olarak kullanıcı adı şifre olarak atanıyor kullanıcı daha sonradan değiştirilebilir.

            var response = await _appUserService.CreateAsync(_mapper.Map<AppUserCreateDto>(model));
            if (response.ResponseType == ResponseType.Success)
            {
                var userResponse = await _appUserService.GetByFilterUser(x => x.Username == model.Username);
                if (userResponse.ResponseType == ResponseType.Success)
                    await _appUserRoleService.CreateAsync(new() { AppRoleId = (int)RoleType.User ,AppUserId = userResponse.Data.Id });
            }
            else
                ViewBag.Message = response.Message;
            return RedirectToAction("UserManagment");
        }
        [HttpGet]
        [Route("Admin/AddTask")]
        public async Task<IActionResult> TaskManagment()
        {
            var response = await _appTaskService.GetPriortiries();

            var user = await _appTaskService.GetUser();
            var userIdsAndNames = user.Data.Select(u => new { Id = u.Id, UserName = u.Username }).ToList();


            if (response.ResponseType == ResponseType.Success)
            {
            
                var model = new AppTaskCreateModel()
                {
                    PriortrySelectList = new SelectList(response.Data, "Id", "Defination"),
                    UserList = new SelectList(userIdsAndNames, "Id", "UserName"),
                    EndDateTime = DateTime.UtcNow

                };
                return View(model);
            }
            ViewBag.Message = "Something went wrong :(";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTask(AppTaskCreateModel model)
        {
            if (ModelState.IsValid)
            {   
                var response = await _appTaskService.CreateAsync(_mapper.Map<AppTaskCreateDto>(model));
                if (response.ResponseType == ResponseType.Success)
                    return RedirectToAction("TaskStatues");
                else
                    return View();
            }
            else
                return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {  

            var response = await _appTaskService.GetByIdAsync(id);
            if (response.ResponseType == ResponseType.Success)
            {
                var priortryResponse = await _appTaskService.GetPriortiries();
                var model = _mapper.Map<AppTaskUpdateModel>(response.Data);

                model.PriortrySelectList = new SelectList(priortryResponse.Data, "Id", "Defination", response.Data.PriortryId);

                return View(model);
            }
            //else 
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _appTaskService.GetByIdAsync(id);
            if (response.ResponseType == ResponseType.Success)
            {
                var responseRemove = await _appTaskService.Remove(response.Data); // RemoveAsync
                if (responseRemove.ResponseType != ResponseType.Success)
                {
                    ViewBag.Message = responseRemove.Message;
                }
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "Bulunamadı"+response.Message;
            return View();

        }
        [HttpGet]
        [Route("Admin/RemoveUser/{id}")]
        public async Task<IActionResult> RemoveUser(int id)
        {
            var response = await _appUserService.GetByIdAsync(id);
            if (response.ResponseType == ResponseType.Success)
            {
                response.Data.IsActive = false;
                var userResponse = await _appUserService.UpdateAsync(_mapper.Map<AppUserUpdateDto>(response.Data));
            }
            else
                ViewBag.Message = "Something went wrong :(";
            return RedirectToAction("UserManagment");
        }
        [HttpPost]
        public async Task<IActionResult> Update(AppTaskUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var updateModel = _mapper.Map<AppTaskUpdateDto>(model);
                var response = await _appTaskService.UpdateAsync(updateModel);
                if (response.ResponseType == ResponseType.Success)
                {
                    ViewBag.Message = $"Başarı ile güncellendi.";
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Message = $"Something went wrong : {response.Message}";
            }
            return View(model);
        }
        public async Task<IActionResult> TaskStatues()
        {
            var response = await _appUserTaskService.GetIncluded();
            if (response.ResponseType == ResponseType.Success)
            {
                return View(response.Data.OrderBy(x=>x.TaskStatusId).OrderByDescending(x=>x.AppTask.CreatedTime).ToList());
            }
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> TaskDetail(int id)
        {
            var response = await _appUserTaskService.GetIncluded(id);
            if (response.ResponseType == ResponseType.Success)
            {
                return View(response.Data);
            }

            return NotFound();
        }

    }
}
