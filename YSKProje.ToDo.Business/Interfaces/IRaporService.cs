using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Interfaces
{
   public interface IRaporService : IGenericService<Rapor>
    {
        Rapor GetirIsIdile(int id);

        int GetirRaporSayiAppUserIdile(int id);
        int GetirRaporSayi();
    }
}
