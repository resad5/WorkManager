using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DTO.DTOs.VaciblikDTOs;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.Stringinfo;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class VaciblikController : Controller
    {
        private readonly IVaciblikService _vaciblikService;

        private readonly IMapper _maper;
        public VaciblikController(IVaciblikService vaciblikService, IMapper maper)
        {
            _maper = maper;
            _vaciblikService = vaciblikService;
        }

        public IActionResult Index()
        {

            TempData["Active"] = TempDataInfo.vaciblik;
            //List<Vaciblik> vaciblikler = _vaciblikService.GetirHepsi();

            //List<VaciblikListViewModel> model = new List<VaciblikListViewModel>();
            //foreach (var item in vaciblikler)
            //{
            //    VaciblikListViewModel vaciblikmodel = new VaciblikListViewModel();
            //    vaciblikmodel.Id = item.Id;
            //    vaciblikmodel.Ifade = item.Ifade;
            //    model.Add(vaciblikmodel);
            //}
            return View(_maper.Map<List<VaciblikListDTO>>(_vaciblikService.GetirHepsi()));
        }

        public IActionResult VaciblikElaveEt()
        {

            TempData["Active"] = TempDataInfo.vaciblik;
            return View(new VaciblikAddDTO());
        }


        [HttpPost]
        public IActionResult VaciblikElaveEt(VaciblikAddDTO model)
        {

            if (ModelState.IsValid)
            {
                _vaciblikService.Kaydet(new Vaciblik() { Ifade=model.Ifade });

                return RedirectToAction("Index");

            }
            return View(model);
        }

        public IActionResult VaciblikYenile(int id)
        {
            TempData["Active"] = TempDataInfo.vaciblik;
            //var vaciblik = _vaciblikService.GetirIdile(id);

            //VaciblikUpdateViewModel model = new VaciblikUpdateViewModel() { Id=vaciblik.Id,Ifade=vaciblik.Ifade };

            return View(_maper.Map<VaciblikUpdateDTO>(_vaciblikService.GetirIdile(id)));
        }

        [HttpPost]
        public IActionResult VaciblikYenile(VaciblikUpdateDTO model)
        {
            TempData["Active"] = TempDataInfo.vaciblik;
            if (ModelState.IsValid)
            {
                var vaciblik = _vaciblikService.GetirIdile(model.Id);
                if (vaciblik!=null)
                {
                    vaciblik.Ifade = model.Ifade;
                    _vaciblikService.Guncelle(vaciblik);
                   
                }
               

              return  RedirectToAction("Index");
            }

            return View(model);
        }


    }
}
