using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Interfaces
{
   public interface IBildirisDal : IGenericDal<Bildiris>
    {
        List<Bildiris> GetirOxunmayanlar(int AppUserId);
        int GetirOxunmamisSayiAppUserIdIle(int AppUserid);
    }
}
