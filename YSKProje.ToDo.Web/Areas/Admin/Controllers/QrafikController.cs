using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Web.Stringinfo;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class QrafikController : Controller
    {
        private readonly IAppUserService _iappuserService;
        public QrafikController(IAppUserService iappuserService)
        {
            _iappuserService = iappuserService;

        }
        public IActionResult Index()
        {
           
            TempData["active"] = TempDataInfo.qrafik;
            return View();
        }

        public IActionResult EnCoxIsTamamlayan()
        {
            var jsonString = JsonConvert.SerializeObject(_iappuserService.GetirEnCoxIsGormusIstifadeciler());
            return Json(jsonString);
        }

        public IActionResult EnCoxIsdeIsleyen()
        {
            var jsonString = JsonConvert.SerializeObject(_iappuserService.GetirEnCoxIsdeIsleyenIstifadeciler());
            return Json(jsonString);
        }



       

    }
}
