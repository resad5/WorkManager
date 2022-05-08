using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.BaseControllers;
using YSKProje.ToDo.Web.Stringinfo;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{

    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class HomeController : BaseIdentityController
    {
       
        private readonly IRaporService _iraporService;
        private readonly IisService _isService;
        private readonly IbildirisService _ibildirisService;
        public HomeController(UserManager<AppUser> usermanager, IRaporService iraporService, IisService isService, IbildirisService ibildirisService):base(usermanager)
        {
            _ibildirisService = ibildirisService;
            _isService = isService;
            _iraporService = iraporService;
           
        }
        public async Task< IActionResult> Index()
        {

            var user = await GetirDaxilOlanIstifadeci();
            ViewBag.IsciGozleyen = _isService.GetirIsciElaveEdilmeyiGozleyenIsSayi();
            ViewBag.tamamlanmisIsSayi = _isService.GetirIsTamamlanmisSayi();
            ViewBag.OxunmamisBildirisSayi = _ibildirisService.GetirOxunmamisSayiAppUserIdIle(user.Id);
            ViewBag.ButunRaporSayi = _iraporService.GetirRaporSayi();
            TempData["active"] = TempDataInfo.EsasSeyife;
            return View();
        }
    }
}
