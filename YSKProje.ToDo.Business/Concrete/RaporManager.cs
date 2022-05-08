using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Concrete
{
    public class RaporManager : IRaporService
    {      

        private readonly IRaporDal _rapordal;
        public RaporManager(IRaporDal rapordal)
        {
            _rapordal = rapordal;
         
        }
        public List<Rapor> GetirHepsi()
        {
           return _rapordal.GetirHepsi();
        }

        public Rapor GetirIdile(int id)
        {

            return _rapordal.GetirIdile(id);
        }

        public Rapor GetirIsIdile(int id)
        {
           return _rapordal.GetirIsIdile(id);
        }

        public int GetirRaporSayi()
        {
            return _rapordal.GetirRaporSayi();
        }

        public int GetirRaporSayiAppUserIdile(int id)
        {
            return _rapordal.GetirRaporSayiAppUserIdile(id);
        }

        public void Guncelle(Rapor tablo)
        {
            _rapordal.Guncelle(tablo);
        }

        public void Kaydet(Rapor tablo)
        {
            _rapordal.Kaydet(tablo);
        }

        public void Sil(Rapor tablo)
        {
            _rapordal.Sil(tablo);
        }
    }
}
