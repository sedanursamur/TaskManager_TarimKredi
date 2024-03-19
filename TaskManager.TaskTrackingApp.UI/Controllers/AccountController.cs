using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManager.TaskTrackingApp.Bussines.Interfaces;
using TaskManager.TaskTrackingApp.Common.Enums;
using TaskManager.TaskTrackingApp.Entities;
using TaskManager.TaskTrackingApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IAppUserRoleService _appUserRoleService;

        public AccountController(IAppUserService appUserService, IAppUserRoleService appUserRoleService)
        {
            _appUserService = appUserService;
            _appUserRoleService = appUserRoleService;
        }

        public IActionResult Login(string returnUrl)
        {
            
            ViewBag.ReturnUrl = returnUrl;
            return View(new UserLoginModel());
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model , string returnUrl)
        {
            var response = await _appUserService.GetByFilterUser(x => x.Username == model.Username);
            if (response.ResponseType == ResponseType.Success)
            {   
                var data = response.Data;
                if (data.Username == model.Username && data.Password == model.Password)
                {
                    var responsrole = await _appUserService.GetRolesByUserIdAsync(data.Id);
                    var claims = new List<Claim>
                    {
                        // To do cookie ayrı bir extension içerisinde olabilir.
                        new Claim(ClaimTypes.Name, data.Username),
                        new Claim(ClaimTypes.NameIdentifier,data.Id.ToString())
                        //new Claim(ClaimTypes.Role, "Administrator"),
                    };

                    foreach (var item in responsrole.Data)
                    {
                        claims.Add(new Claim (ClaimTypes.Role, item.Defination));
                    }

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                         IsPersistent = model.RememberMe,
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    if (returnUrl != null)
                        return Redirect(returnUrl);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı veya şifre yanlış");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı Adı Bulunamadı");
                return View(model);
            }
        }


        public IActionResult Register()
        {
            return View(new UserRegisterModel());
        }

        //[HttpPost]
        //public async Task<IActionResult> Register(UserRegisterModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Kullanıcıyı oluştur
        //        var user = new AppUser
        //        {
        //            FirstName = model.FirstName,
        //            LastName = model.LastName,
        //            Username = model.UserName,
        //            Email = model.Email,
        //            Password = model.Password,
        //            IsActive = true // Varsayılan olarak aktif
        //        };

        //        // Kullanıcıyı veritabanına ekle
        //        var result = await _appUserService.CreateUserAsync(user);

        //        if (result.ResponseType == ResponseType.Success)
        //        {
        //            // Kayıt başarılıysa giriş sayfasına yönlendir
        //            return RedirectToAction("Login", "Account");
        //        }
        //        else
        //        {
        //            // Kayıt başarısızsa hata mesajını göster
        //            ModelState.AddModelError("", result.Message);
        //        }
        //    }

        //    // Model geçersizse veya kayıt başarısızsa kayıt sayfasını tekrar göster
        //    return View(model);
        //}


        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(
       CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
