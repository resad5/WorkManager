using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Business.Concrete;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Business.ValidationRules.FluentValidation;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.DTO.DTOs.AppUserDTOs;
using YSKProje.ToDo.DTO.DTOs.IsDTOs;
using YSKProje.ToDo.DTO.DTOs.RaporDTOs;
using YSKProje.ToDo.DTO.DTOs.VaciblikDTOs;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Web.CustomCollectionsExtentios
{
    public static class CollectionExtention
    {
       public static void AddCustomIdentity(this IServiceCollection services)
        {

            services.AddDbContext<TodoContext>();
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;



            })
                .AddEntityFrameworkStores<TodoContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "IsIzlemeCookie";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = new PathString("/Hame/Giris");
            });

        }

        public static void AddCustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AppUserAddDTO>, AppUserAddValidator>();
            services.AddTransient<IValidator<AppUserSignInDTO>, AppUserSignInValidator>();
            services.AddTransient<IValidator<IsAddDTO>, IsAddValidator>();
            services.AddTransient<IValidator<IsUpdateDTO>, IsUpdateValidator>();
            services.AddTransient<IValidator<RaporAddDTO>, RaporAddValidator>();
            services.AddTransient<IValidator<RaporUpdateDTO>, RaporUpdateValidator>();
            services.AddTransient<IValidator<VaciblikAddDTO>, VaciblikAddValidator>();
            services.AddTransient<IValidator<VaciblikUpdateDTO>, VaciblikUpdateValidation>();
        }
    }
}
