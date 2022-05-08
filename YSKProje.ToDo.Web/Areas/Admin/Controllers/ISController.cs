using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DTO.DTOs.IsDTOs;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.Stringinfo;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class ISController : Controller
    {
        private readonly IisService _isService;
        private readonly IVaciblikService _vaciblikService;
        private readonly IMapper _maper;

        public ISController(IisService isService, IVaciblikService vaciblikService, IMapper maper)
        {
            _maper = maper;
            _isService = isService;
            _vaciblikService = vaciblikService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.IS;

            //List<Is> isler = _isService.GetirVaciblikTamamlanmayan();
            //List<ISListViewModel> models = new List<ISListViewModel>();

            //foreach (var item in isler)
            //{
            //    ISListViewModel islist = new ISListViewModel();
            //    islist.Aciklama = item.Aciklama;
            //    islist.Ad = item.Ad;
            //    islist.Durum = item.Durum;
            //    islist.Id = item.Id;
            //    islist.OlusturulmaTarih = item.OlusturulmaTarih;
            //    islist.VaciblikId = item.VaciblikId;
            //    islist.Vaciblik = item.Vaciblik;

            //    models.Add(islist);
            //}

    
            return View(_maper.Map<List<IsListDTO>>(_isService.GetirVaciblikTamamlanmayan()));
        }

        public IActionResult IsYarat()
        {
            TempData["Active"] = TempDataInfo.IS;

            ViewBag.Vacikliks = new SelectList(_vaciblikService.GetirHepsi(), "Id", "Ifade");
            return View(new IsAddDTO());
        }


        [HttpPost]
        public IActionResult IsYarat(IsAddDTO model)
        {
            if (ModelState.IsValid)
            {
                Is tapsiriq = new Is();
                tapsiriq.Ad = model.Ad;
                tapsiriq.Aciklama = model.Aciklama;
                tapsiriq.VaciblikId = model.VaciblikId;
                _isService.Kaydet(tapsiriq);

               
                return RedirectToAction("Index");
            }
            ViewBag.Vacikliks = new SelectList(_vaciblikService.GetirHepsi(), "Id", "Ifade", model.VaciblikId);
            return View(new IsAddDTO());
        }

        public IActionResult IsYenile( int id)
        {
            TempData["Active"] = TempDataInfo.IS;
            var tapsiriq = _isService.GetirIdile( id);

            //IsUpdateViewModel model = new IsUpdateViewModel()
            //{
            //    Id = tapsiriq.Id,
            //    Aciklama = tapsiriq.Aciklama,
            //    Ad = tapsiriq.Ad,
            //    VaciblikId = tapsiriq.VaciblikId
               
            //};
            ViewBag.Vacikliks = new SelectList(_vaciblikService.GetirHepsi(), "Id", "Ifade",tapsiriq.VaciblikId);
            return View(_maper.Map<IsUpdateDTO>(tapsiriq));
        }


        [HttpPost]
        public IActionResult IsYenile(IsUpdateDTO model)
        {

            if (ModelState.IsValid)
            {

                var IS = _isService.GetirIdile(model.Id);
                if (IS!=null)
                {
                    IS.Aciklama = model.Aciklama;
                    IS.Ad = model.Ad;
                    IS.VaciblikId = model.VaciblikId;


                    _isService.Guncelle(IS);

                    return RedirectToAction("Index");
                    
                }
               
            }
            ViewBag.Vacikliks = new SelectList(_vaciblikService.GetirHepsi(), "Id", "Ifade", model.VaciblikId);
            return View(model);
        }


      public IActionResult IsSil(int id)
        {
            var IS = _isService.GetirIdile(id);
            if (IS != null)
            {
                _isService.Sil(IS);
            }

            return Json(null);
        }
    }
}
