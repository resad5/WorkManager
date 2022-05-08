using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DTO.DTOs.IsDTOs;
using YSKProje.ToDo.DTO.DTOs.RaporDTOs;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.BaseControllers;
using YSKProje.ToDo.Web.Stringinfo;

namespace YSKProje.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class IsEmri : BaseIdentityController
    {
        private readonly IAppUserService _appUserService;
        private readonly IbildirisService _bildirimService;
        private readonly IisService _isService;
  
        private readonly IRaporService _raporService;
        private readonly IMapper _mapper;
        public IsEmri(IAppUserService appUserService, IisService isService, UserManager<AppUser> usermanager, IRaporService raporService, IbildirisService bildirimService, IMapper mapper):base(usermanager)
        {
            _mapper = mapper;
            _raporService = raporService;
          
            _isService = isService;
            _appUserService = appUserService;
            _bildirimService = bildirimService;
        }
        public async Task<IActionResult> Index()
        {

            TempData["Active"] = TempDataInfo.İsEmirleri;


            var user = await GetirDaxilOlanIstifadeci();
            var IS = _mapper.Map<List<IsListAllDTO>>(_isService.GetirButunCedvellerle(i => i.AppUser.Name == user.Name && !i.Durum)); ;

            //List<IsListAllViewModel> models = new List<IsListAllViewModel>();

            //foreach (IS item in IS)
            //{
            //    IsListAllViewModel model = new IsListAllViewModel();

            //    model.Ad = item.Ad;
            //    model.Aciklama = item.Aciklama;
            //    model.AppUser = item.AppUser;
            //    model.Id = item.Id;
            //    model.OlusturulmaTarih = item.OlusturulmaTarih;
            //    model.Rapors = item.Rapors;
            //    model.Vaciblik = item.Vaciblik;

            //    models.Add(model);
            //}
            return View(IS);
        }


        public IActionResult RaporYaz(int id)
        {
            TempData["Active"] = TempDataInfo.İsEmirleri;

            var IS = _isService.GetirVaciblikIdIle(id);
            RaporAddDTO model = new RaporAddDTO();

            model.IsId = id;
            model.Is = IS;


            return View(model);

        }


        [HttpPost]
        public async Task<IActionResult> RaporYaz(RaporAddDTO model)
        {
            TempData["Active"] = TempDataInfo.İsEmirleri;
            if (ModelState.IsValid)
            {
                _raporService.Kaydet(new Rapor() { IsId = model.IsId, Detay = model.Detay, Tanim = model.Tanim });


                var user = await GetirDaxilOlanIstifadeci();

                var adminUsers = await _userManager.GetUsersInRoleAsync("Admin");

                foreach (var Auser in adminUsers)
                {
                    _bildirimService.Kaydet(
                       new Bildiris
                       {
                           Aciklama = $"{user.Name} {user.Surname} yeni bir rapor yazdi",
                           AppUserId = Auser.Id

                       });
                    ;


                }
                return RedirectToAction("Index");
            }

            return View();

        }

        public IActionResult YenileRapor(int id)
        {
            TempData["Active"] = TempDataInfo.İsEmirleri;
            var rapor =_raporService.GetirIsIdile(id);

            RaporUpdateDTO model = new RaporUpdateDTO();
            model.Detay = rapor.Detay;
            model.Id = rapor.Id;
            model.Tanim = rapor.Tanim;
            model.IsId = rapor.IsId;
            model.Is = rapor.Is;

            return View(model);
        }

        [HttpPost]
        public IActionResult YenileRapor(RaporUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var rapor = _raporService.GetirIdile(model.Id);
                rapor.Tanim = model.Tanim;
                rapor.Detay = model.Detay;

                _raporService.Guncelle(rapor);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public async Task<IActionResult> TamamlaIs(int id)
        {
            var tapsiriq = _isService.GetirIdile(id);
            tapsiriq.Durum = true;
            _isService.Guncelle(tapsiriq);

            var user = await GetirDaxilOlanIstifadeci();

            var adminUsers = await _userManager.GetUsersInRoleAsync("Admin");

            foreach (var Auser in adminUsers)
            {
                _bildirimService.Kaydet(
                   new Bildiris
                   {
                       Aciklama = $"{user.Name} {user.Surname} verdiyiniz bir isi tamamladi",
                       AppUserId = Auser.Id

                   });
                ;


            }
            return Json(null);
        }
    }
}
