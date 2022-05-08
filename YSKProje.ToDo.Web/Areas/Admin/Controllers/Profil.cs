using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.DTO.DTOs.AppUserDTOs;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.BaseControllers;
using YSKProje.ToDo.Web.Stringinfo;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class Profil : BaseIdentityController
    {
        private readonly IMapper _maper;
    
        public Profil(UserManager<AppUser> usermanager, IMapper maper):base(usermanager)
        {
            _maper = maper;
          
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempDataInfo.Profil;
            //var appuser = await _usermanager.FindByNameAsync(User.Identity.Name);
            //AppUserListViewModel model = new AppUserListViewModel();
            //model.Id = appuser.Id;
            //model.Surname = appuser.Surname;
            //model.Name = appuser.Name;
            //model.Email = appuser.Email;
            //model.Picture = appuser.Picture;

        
            return View(_maper.Map<AppUserListDTO>(await GetirDaxilOlanIstifadeci()));
        }


        [HttpPost]
        public async Task<IActionResult> Index(AppUserListDTO model, IFormFile resim)
        {

            if (ModelState.IsValid)
            {
                var yenilenecelIstifadeci = _userManager.Users.FirstOrDefault(i => i.Id == model.Id);
                if (resim != null)
                {
                    string resimuzanti = Path.GetExtension(resim.FileName);

                    string resimAdi = Guid.NewGuid() + resimuzanti;

                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + resimAdi);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await resim.CopyToAsync(stream);
                    };

                    yenilenecelIstifadeci.Picture = resimAdi;
                }
                yenilenecelIstifadeci.Name = model.Name;
                yenilenecelIstifadeci.Surname = model.Surname;
                yenilenecelIstifadeci.Email = model.Email;


              var result= await _userManager.UpdateAsync(yenilenecelIstifadeci);

                if (result.Succeeded)
                {
                    TempData["message"] = "Melumatlar yenilendi";
                    return RedirectToAction("Index");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
               
            }
            return View(model);
        }
    }
}
