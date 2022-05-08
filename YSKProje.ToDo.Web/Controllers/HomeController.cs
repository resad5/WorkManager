using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DTO.DTOs.AppUserDTOs;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.BaseControllers;
using YSKProje.ToDo.Web.Models;

namespace YSKProje.ToDo.Web.Controllers
{
    public class HomeController : BaseIdentityController
    {

        private readonly ICustomLogger _customLogger;
        private readonly SignInManager<AppUser> _signInManager;
       private readonly IisService _tasService;
       
        public HomeController(IisService tasService, UserManager<AppUser> usermanager, SignInManager<AppUser> signInManager, ICustomLogger customLogger) :base(usermanager)
        {
            _customLogger = customLogger;
            _signInManager = signInManager;
            _tasService = tasService;
           
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Qeydiyyat()
        {
            return View();
        }


        [HttpPost]
        public async Task< IActionResult> Giris(AppUserSignInDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user!=null)
                {

                   var result= await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememmberMe, false);
                    if (result.Succeeded)
                    {
                        var rollar = await _userManager.GetRolesAsync(user);
                        if (rollar.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });

                        }

                    }

                }

                ModelState.AddModelError("", "Istifadeci adi ve ya sifre yanlisdir");

            }

            return View("Index", model);
        }


        [HttpPost]
        public async Task< IActionResult> Qeydiyyat(AppUserAddDTO model)
        {

            
            if (ModelState.IsValid)
            {

                AppUser user = new AppUser
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    UserName = model.UserName,
                    Email = model.Email
                };
              var identityresult= await _userManager.CreateAsync(user,model.Password);

                if (identityresult.Succeeded)
                {
                 var roleaddresult=   await _userManager.AddToRoleAsync(user, "Member");
                    if (roleaddresult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var item in roleaddresult.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }

                }

                else
                {

                    foreach (var item in identityresult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    
                }
                
            }

           
             return View(model);
        }


        public async Task<IActionResult> Cixis()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        public IActionResult StatusCode(int? code)
        {
            if (code==404)
            {
                ViewBag.code = code;
                ViewBag.Message = "Seyife Tapilmadi";
            }
            return View();
        }

        public IActionResult Error()
        {
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            _customLogger.LogError($"Xetanin bas verdiyi yer: {exceptionHandler.Path} \n Xetanin mesaji: {exceptionHandler.Error.Message} \n Stack Trace: {exceptionHandler.Error.StackTrace}");
            ViewBag.Path = exceptionHandler.Path;
            ViewBag.Message = exceptionHandler.Error.Message;

            return View();
        }

        public void Xeta()
        {
            throw new Exception("Bur bir xetadir");
        }
    }
}
