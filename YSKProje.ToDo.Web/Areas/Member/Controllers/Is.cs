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
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.BaseControllers;
using YSKProje.ToDo.Web.Stringinfo;

namespace YSKProje.ToDo.Web.Areas.Member.Controllers
{

    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class Is : BaseIdentityController
    {
        private readonly IAppUserService _appUserService;
        private readonly IisService _isService;

        private readonly IRaporService _raporService;
        private readonly IMapper _mapper;
        public Is(IAppUserService appUserService, IisService isService, UserManager<AppUser> usermanager, IRaporService raporService, IMapper mapper):base(usermanager)
        {
            _mapper = mapper;
             _raporService = raporService;
         
            _isService = isService;
            _appUserService = appUserService;
        }
        public async Task<IActionResult> Index(int aktSayfa=1)
        {
            TempData["Active"] =TempDataInfo.IS;
            var user = await GetirDaxilOlanIstifadeci();

            int cemiSeyife;
          var Isler= _mapper.Map<List<IsListAllDTO>>(_isService.GetiButunCedvelTamamlanmayan(out cemiSeyife, user.Id, aktSayfa));


            ViewBag.ToplamSeyife = cemiSeyife;
            ViewBag.AktivSeyife = aktSayfa;

            //List<IsListAllViewModel> models = new List<IsListAllViewModel>();

            //foreach (var IS in Isler)
            //{

            //    IsListAllViewModel model = new IsListAllViewModel();
            //    model.Id = IS.Id;
            //    model.Aciklama = IS.Aciklama;
            //    model.Ad = IS.Ad;
            //    model.AppUser = IS.AppUser;
            //    model.OlusturulmaTarih = IS.OlusturulmaTarih;
            //    model.Rapors = IS.Rapors;
            //    model.Vaciblik = IS.Vaciblik;
            //    models.Add(model);
            //}

            
            return View(Isler);
        }
    }
}
