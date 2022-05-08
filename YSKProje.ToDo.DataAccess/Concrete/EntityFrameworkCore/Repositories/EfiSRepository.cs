using System.Collections.Generic;
using System.Linq;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;

namespace YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfiSRepository : EfGenericRepository<Is>, IiSDal
    {
        public List<Is> GetirAppUserId(int id)
        {
            var context = new TodoContext();

            return context.Isler.Where(i => i.AppUserId == id).ToList();
        }

        public List<Is> GetirButunCedvellerle()
        {
            using var context = new TodoContext();
            return context.Isler.Include(i => i.Vaciblik)
                .Include(i => i.AppUser)
                .Include(i => i.Rapors)
                .Where(i => i.Durum == false)
                .OrderByDescending(i => i.OlusturulmaTarih).ToList();
        }

        public Is GetirVaciblikIdIle(int id)
        {
            using var context = new TodoContext();
            return context.Isler.Include(i => i.Vaciblik)
                 .FirstOrDefault(i => i.Durum == false&&i.Id==id);
                  
        }

        public List<Is> GetirVaciblikTamamlanmayan()
        {
            using var context = new TodoContext();
            return context.Isler.Include(i => i.Vaciblik)
                 .Where(i => i.Durum == false)
                 .OrderByDescending(i => i.OlusturulmaTarih).ToList();
        }

        public Is  GetirRaporlarileId(int id)
        {
            var context = new TodoContext();

           return context.Isler.Include(i => i.Rapors).Include(i=>i.AppUser).Where(i => i.Id == id).FirstOrDefault();
        }

        public List<Is> GetirButunCedvellerle(Expression<Func<Is, bool>> filter)
        {
            using var context = new TodoContext();
            return context.Isler.Include(i => i.Vaciblik)
                .Include(i => i.AppUser)
                .Include(i => i.Rapors)
                .Where(filter)
                .OrderByDescending(i => i.OlusturulmaTarih).ToList();
        }

        public List<Is> GetiButunCedvelTamamlanmayan(out int toplamSayfa, int userid, int aktseyfe=1)
        {
            using var context = new TodoContext();
            var returnvalue = context.Isler.Include(i => i.Vaciblik)
                .Include(i => i.AppUser)
                .Include(i => i.Rapors)
                .Where(i => i.AppUserId == userid&&i.Durum)
                .OrderByDescending(i => i.OlusturulmaTarih);

            toplamSayfa = (int)Math.Ceiling((double)returnvalue.Count() / 3);

            return returnvalue.Skip((aktseyfe - 1) * 3).Take(3).ToList();
        }

        public int GetirIsSayiTamamlananAppUserIdile(int id)
        {
            using var context = new TodoContext();

            return context.Isler.Count(i => i.AppUserId == id && i.Durum);
        }

        public int GetirIsSayiTamamlanmasiGerekenAppUserIdile(int id)
        {
            using var context = new TodoContext();

            return context.Isler.Count(i => i.AppUserId == id && !i.Durum);
        }

        public int GetirIsciElaveEdilmeyiGozleyenIsSayi()
        {
            using var context = new TodoContext();
            int say= context.Isler.Count(i => i.AppUserId == null && !i.Durum);
            return say;
        }

        public int GetirIsTamamlanmisSayi()
        {
            using var context = new TodoContext();

            return context.Isler.Count( i=>i.Durum);
        }
    }
}
