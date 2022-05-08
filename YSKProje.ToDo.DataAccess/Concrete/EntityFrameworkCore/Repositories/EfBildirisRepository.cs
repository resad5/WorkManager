using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfBildirisRepository : EfGenericRepository<Bildiris>, IBildirisDal
    {
        public int GetirOxunmamisSayiAppUserIdIle(int AppUserid)
        {
            using var context = new TodoContext();
            return context.Bildirises.Count(b => b.AppUserId == AppUserid && !b.Drum);
        }

        public List<Bildiris> GetirOxunmayanlar(int AppUserId)
        {
            using var context = new TodoContext();
            return context.Bildirises.Where(b => b.AppUserId == AppUserId && !b.Drum).ToList();

        }
    }
}
