using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Business.Concrete;
using YSKProje.ToDo.Business.CustomLogger;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using YSKProje.ToDo.DataAccess.Interfaces;

namespace YSKProje.ToDo.Business.DiConteiner
{
   public  static class CustomExtensions
    {
        public static void AddConteinerWithDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDosyaService, DosyaManager>();
            services.AddScoped<IisService, ISManager>();
            services.AddScoped<IRaporService, RaporManager>();
            services.AddScoped<IVaciblikService, VaciblikManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IiSDal, EfiSRepository>();
            services.AddScoped<IRaporDal, EfRaporRepository>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IBildirisDal, EfBildirisRepository>();
            services.AddScoped<IbildirisService, BildirisManager>();
            services.AddScoped<IVaciblikDal, EFVaciblikRepository>();


            services.AddTransient<ICustomLogger, NLogLoger>();
        }
    }
}
