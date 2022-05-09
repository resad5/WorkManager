    using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : IAppUserDal
    {

        public List<AppUser> GetirAdminOlmayanlar(out int toplamSeyife, string axtarilacaqsoz, int aktivseyife = 1)
        {
            using var context = new TodoContext();

            var result = context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole
            }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (ResultTable, resultRole) => new
            {

                user = ResultTable.user,
                userRoles = ResultTable.userRole,
                roles = resultRole

            }).Where(I => I.roles.Name == "Member").Select(I => new AppUser
            {
                Name = I.user.Name,
                Surname = I.user.Surname,
                Email = I.user.Email,
                Picture = I.user.Picture,
                UserName = I.user.UserName,
                Id = I.user.Id,


            });

            toplamSeyife = (int)Math.Ceiling((double)result.Count() / 3);

            if (!string.IsNullOrWhiteSpace(axtarilacaqsoz))
            {
                result = result.Where(r => r.Name.ToLower().Contains(axtarilacaqsoz.ToLower())
                || r.Surname.ToLower().Contains(axtarilacaqsoz.ToLower()));
                toplamSeyife = (int)Math.Ceiling((double)result.Count() / 3);
            }


            result = result.Skip((aktivseyife - 1) * 3).Take(3);

            return result.ToList();
        }
        public List<AppUser> GetirAdminOlmayanlar()
        {
            using var context = new TodoContext();

            return context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole
            }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (ResultTable, resultRole) => new
            {

                user = ResultTable.user,
                userRoles = ResultTable.userRole,
                roles = resultRole

            }).Where(I => I.roles.Name == "Member").Select(I => new AppUser
            {
                Name = I.user.Name,
                Surname = I.user.Surname,
                Email = I.user.Email,
                Picture = I.user.Picture,
                UserName = I.user.UserName,
                Id = I.user.Id,


            }).ToList();
        }


        public List<DualHelper> GetirEnCoxIsGormusIstifadeciler()
        {
            var context = new TodoContext();
            return context.Isler.Include(i => i.AppUser).Where(i => i.Durum).GroupBy(i => i.AppUser.UserName)
                .OrderByDescending(i => i.Count()).Take(5).Select(i => new DualHelper { Ad = i.Key, IsSayi = i.Count() }).ToList();

        }
        public List<DualHelper> GetirEnCoxIsdeIsleyenIstifadeciler()
        {
            var context = new TodoContext();
            return context.Isler.Include(i => i.AppUser).Where(i => !i.Durum && i.AppUserId != null).GroupBy(i => i.AppUser.UserName)
                .OrderByDescending(i => i.Count()).Take(5).Select(i => new DualHelper { Ad = i.Key, IsSayi = i.Count() }).ToList();



        }

       
    }
}
