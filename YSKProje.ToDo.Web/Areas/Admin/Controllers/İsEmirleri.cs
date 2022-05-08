using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DTO.DTOs.AppUserDTOs;
using YSKProje.ToDo.DTO.DTOs.IsDTOs;
using YSKProje.ToDo.DTO.DTOs.RaporDTOs;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.BaseControllers;
using YSKProje.ToDo.Web.Stringinfo;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class İsEmirleri : BaseIdentityController
    {
        private readonly IAppUserService _appUserService;
        private readonly IbildirisService _ibildirisService;
        private readonly IisService _isService;
        
        private readonly IDosyaService _dosyaService;
        private readonly IMapper _maper;
        public İsEmirleri(IAppUserService appUserService, IisService isService,UserManager<AppUser> usermanager, IDosyaService dosyaService, IbildirisService ibildirisService, IMapper maper):base(usermanager)
        {

            _maper = maper;
            _ibildirisService = ibildirisService;
         
            _isService = isService;
            _appUserService = appUserService;
            _dosyaService = dosyaService;
        }
       

        public IActionResult GetirExcel(int id)
        {
           
          return File ( _dosyaService.AKtExcel(_maper.Map<List<RaporFileDTO>>(_isService.GetirRaporlarileId(id).Rapors)),
              "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",Guid.NewGuid()+".xlsx");
           
        }

        public IActionResult GetirPdf(int id)
        {
            var path = _dosyaService.AktPdf(_maper.Map<List<RaporFileDTO>>( _isService.GetirRaporlarileId(id).Rapors));
            return File(path,"application/pdf", Guid.NewGuid() + ".pdf");

        }
        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.İsEmirleri;

          //List<Is> isler = _isService.GetirButunCedvellerle();
            //List<IsListAllViewModel> models = new List<IsListAllViewModel>();

            // foreach (var item in isler)
            // {
            //     IsListAllViewModel model = new IsListAllViewModel();
            //     model.Aciklama = item.Aciklama;             
            //     model.Ad = item.Ad;
            //     model.Vaciblik = item.Vaciblik;            
            //     model.Id = item.Id;
            //     model.OlusturulmaTarih = item.OlusturulmaTarih;
            //     model.AppUser = item.AppUser;              
            //     model.OlusturulmaTarih = item.OlusturulmaTarih;
            //     model.Rapors = item.Rapors;

            //     models.Add(model);

            // }


            return View(_maper.Map<List<IsListAllDTO>>(_isService.GetirButunCedvellerle()));

            //return View(_appUserService.GetirAdminOlmayanlar());
        }

        public IActionResult DetayGoster(int id)
        {
            TempData["Active"] = TempDataInfo.İsEmirleri;

            //var IS= _isService.GetirRaporlarileId(id);
            //IsListAllViewModel model = new IsListAllViewModel();
            //model.Id = IS.Id;
            //model.Aciklama = IS.Aciklama;
            //model.Ad = IS.Ad;
            //model.Rapors = IS.Rapors;
            //model.AppUser = IS.AppUser;

            return View(_maper.Map<IsListAllDTO>(_isService.GetirRaporlarileId(id)));

        }
        public IActionResult TapsiriqaIsciElaveEt(int id,string s,int sayfa=1)
        {

            ViewBag.Axrarilan = s;

            ViewBag.AktivSeyife = sayfa;

            //ViewBag.ToplamSeyife =(int)Math.Ceiling((double) _appUserService.GetirAdminOlmayanlar().Count/3);
            TempData["Active"] = TempDataInfo.İsEmirleri;



            var personeller = _appUserService.GetirAdminOlmayanlar(out int toplamSeyife, s, sayfa);
            ViewBag.ToplamSeyife = toplamSeyife;


            var appuserlistmodel =_maper.Map<List<AppUserListDTO>>(_appUserService.GetirAdminOlmayanlar(out toplamSeyife, s, sayfa));
            //List<AppUserListViewModel> appuserlistmodel = new List<AppUserListViewModel>();

            //foreach (var item in personeller)
            //{
            //    AppUserListViewModel model = new AppUserListViewModel();
            //    model.Email = item.Email;
            //    model.Id = item.Id;
            //    model.Surname = item.Surname;
            //    model.Name = item.Name;
            //    model.Picture = item.Picture;

            //    appuserlistmodel.Add(model);


            //}

            ViewBag.personeller = appuserlistmodel;
         
            //var gorev = _isService.GetirVaciblikIdIle(id);

            //ISListViewModel Ismodel = new ISListViewModel();
            //Ismodel.Ad = gorev.Ad;
            //Ismodel.Aciklama = gorev.Aciklama;
            //Ismodel.Id = gorev.Id;
            //Ismodel.Durum = gorev.Durum;
            //Ismodel.Vaciblik = gorev.Vaciblik;
            //Ismodel.OlusturulmaTarih = gorev.OlusturulmaTarih;
           

            return View(_maper.Map<IsListDTO>(_isService.GetirVaciblikIdIle(id)));
        }





        public IActionResult Isciler()
        {
          var isciler= _maper.Map<List<AppUserListDTO>>(_appUserService.GetirAdminOlmayanlarHamisi());
         
            return View(isciler);
        }
        





        [HttpPost]
        public IActionResult TapsiriqaIsciElaveEt(IsciGorevlendirDTO model)
        {
            TempData["Active"] = TempDataInfo.İsEmirleri;
            var yenilenecekIs = _isService.GetirVaciblikIdIle(model.IsId);
            yenilenecekIs.AppUserId = model.IsciId;
            _isService.Guncelle(yenilenecekIs);

           

            _ibildirisService.Kaydet(new Bildiris { AppUserId=model.IsciId,Aciklama=$"{yenilenecekIs.Ad} adli iş sizə tapsirildi"});

            return RedirectToAction("Index");
        }

        public IActionResult GorevLendirIsci(IsciGorevlendirDTO model)
        {
            TempData["Active"] = TempDataInfo.İsEmirleri;

            IsciGorevlendirListDTO iscigorevlistmodel = new IsciGorevlendirListDTO();
            iscigorevlistmodel.AppUser = _maper.Map<AppUserListDTO>(_userManager.Users.FirstOrDefault(u => u.Id == model.IsciId));
            iscigorevlistmodel.Is = _maper.Map<IsListDTO>(_isService.GetirVaciblikIdIle(model.IsId));

            return View(iscigorevlistmodel);





            //var user = _usermanager.Users.FirstOrDefault(u => u.Id == model.IsciId);
            //AppUserListViewModel userModel = new AppUserListViewModel();
            //userModel.Id = user.Id;
            //userModel.Name = user.Name;
            //userModel.Email = user.Email;
            //userModel.Surname = user.Surname;
            //userModel.Picture = user.Picture;



            //var Is = _isService.GetirVaciblikIdIle(model.IsId);
            //ISListViewModel isModel = new ISListViewModel();
            //isModel.Id = Is.Id;
            //isModel.Aciklama = Is.Aciklama;
            //isModel.Durum = Is.Durum;
            //isModel.OlusturulmaTarih = Is.OlusturulmaTarih;
            //isModel.Ad = Is.Ad;
            //isModel.Vaciblik = Is.Vaciblik;
        }
    }
}
