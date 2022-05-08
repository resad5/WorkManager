using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DTO.DTOs.BildirisDTOs;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.BaseControllers;
using YSKProje.ToDo.Web.Stringinfo;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{

    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class BildirisController : BaseIdentityController
    {

        private readonly IbildirisService _bildrimService;
      
        private readonly IMapper _maper;
        public BildirisController(UserManager<AppUser> usermanager, IbildirisService bildrimService, IMapper maper):base(usermanager)
        {
            _maper = maper;
            _bildrimService = bildrimService;
          
        }

        public async  Task<IActionResult> Index()
        {
            TempData["Active"] = TempDataInfo.Bildiris;
            var user = await GetirDaxilOlanIstifadeci();

            //var bildirisler = _bildrimService.GetirOxunmayanlar(user.Id);

            //var models = new List<BildirisListViewModel>();

            //foreach (var bildiris in bildirisler)
            //{
            //    var model = new BildirisListViewModel();
            //    model.Id = bildiris.Id; 
            //    model.Aciklama = bildiris.Aciklama;

            //    models.Add(model);
            //}
            
            return View(_maper.Map<List<BildirisListDTO>>(_bildrimService.GetirOxunmayanlar(user.Id)));
        }


        [HttpPost]
        public IActionResult Index(int Id)
        {
            var bildiris = _bildrimService.GetirIdile(Id);
            bildiris.Drum = true;
            _bildrimService.Guncelle(bildiris);
            return RedirectToAction("Index");
        }
    }
}
