using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Concrete
{
    public class BildirisManager : IbildirisService
    {
        private readonly IBildirisDal _bildirisdal;
        public BildirisManager(IBildirisDal bildirisdal)
        {
            _bildirisdal = bildirisdal;

        }
        public List<Bildiris> GetirHepsi()
        {
            return _bildirisdal.GetirHepsi();
        }

        public Bildiris GetirIdile(int id)
        {
            return _bildirisdal.GetirIdile(id);
        }

        public int GetirOxunmamisSayiAppUserIdIle(int AppUserid)
        {
           return _bildirisdal.GetirOxunmamisSayiAppUserIdIle(AppUserid);
        }

        public List<Bildiris> GetirOxunmayanlar(int AppUserId)
        {
            return _bildirisdal.GetirOxunmayanlar(AppUserId);
        }

        public void Guncelle(Bildiris tablo)
        {
             _bildirisdal.Guncelle(tablo);
        }

        public void Kaydet(Bildiris tablo)
        {
             _bildirisdal.Kaydet(tablo);
        }

        public void Sil(Bildiris tablo)
        {
            _bildirisdal.Kaydet(tablo);
        }
    }
}
