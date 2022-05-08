using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DTO.DTOs.AppUserDTOs;
using YSKProje.ToDo.Entities.Concrete;


namespace YSKProje.ToDo.Web.ViewComponents
{
    public class Wraper : ViewComponent
    {
        private readonly IbildirisService _bildrimService;
        private readonly UserManager<AppUser> _usermanager;
        private readonly IMapper _mapper;
        public Wraper(UserManager<AppUser> usermanager, IbildirisService bildrimService, IMapper mapper)
        {

            _mapper = mapper;
            _bildrimService = bildrimService;
            _usermanager = usermanager;
        }

        public IViewComponentResult Invoke()
        {
            var user = _usermanager.FindByNameAsync(User.Identity.Name).Result;

            var bildirisler = _bildrimService.GetirOxunmayanlar(user.Id).Count;

            ViewBag.BildirisSayi = bildirisler;

            //AppUserListViewModel model = new AppUserListViewModel();
            //model.Id = user.Id;
            //model.Surname = user.Surname;
            //model.Name = user.Name;
            //model.Email = user.Email;
            //model.Picture = user.Picture;



           var model= _mapper.Map<AppUserListDTO>(_usermanager.FindByNameAsync(User.Identity.Name).Result);
            var roles = _usermanager.GetRolesAsync(user).Result;
            if (roles.Contains("Admin"))
            {
                return View(model);
            }

            else
            {
                return View("Member",model);
            }
           
        }
    }
}
