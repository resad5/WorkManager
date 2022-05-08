using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Interfaces
{
   public interface IbildirisService:IGenericService<Bildiris>
    {
        List<Bildiris> GetirOxunmayanlar(int AppUserId);
        int GetirOxunmamisSayiAppUserIdIle(int AppUserid);
    }
}
