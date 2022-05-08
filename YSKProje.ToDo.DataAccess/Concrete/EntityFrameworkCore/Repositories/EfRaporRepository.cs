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
    public class EfRaporRepository : EfGenericRepository<Rapor>, IRaporDal
    {
        public Rapor GetirIsIdile(int id)
        {
            using var context = new TodoContext();

            return context.Rapors.Include(R => R.Is).ThenInclude(I=>I.Vaciblik).Where(R => R.Id == id).FirstOrDefault();
        }

        public int GetirRaporSayi()
        {
            using var context = new TodoContext();

            return context.Rapors.Count();
        }

        public int GetirRaporSayiAppUserIdile(int id)
        {
            using var context = new TodoContext();
            var result = context.Isler.Include(i => i.Rapors).Where(i => i.AppUserId == id);

            return result.SelectMany(i => i.Rapors).Count();
        }
    }
}
