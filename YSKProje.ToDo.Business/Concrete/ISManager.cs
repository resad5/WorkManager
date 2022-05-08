using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Concrete
{
   public  class ISManager : IisService
    {


        private readonly IiSDal _taskDal;
        public ISManager(IiSDal taskdal)
        {
            _taskDal = taskdal;
          
        }

        public List<Is> GetiButunCedvelTamamlanmayan(out int toplamSayfa, int userid, int aktseyfe=1)
        {
            return _taskDal.GetiButunCedvelTamamlanmayan(out toplamSayfa, userid, aktseyfe);
        }

        public List<Is> GetirAppUserId(int id)
        {
            return _taskDal.GetirAppUserId(id) ;
        }

        public List<Is> GetirButunCedvellerle()
        {
           return _taskDal.GetirButunCedvellerle();
        }

        public List<Is> GetirButunCedvellerle(Expression<Func<Is, bool>> filter)
        {
            return _taskDal.GetirButunCedvellerle(filter);
        }

        public List<Is> GetirHepsi()
        {
            return _taskDal.GetirHepsi();
        }

        public Is GetirIdile(int id)
        {
            return _taskDal.GetirIdile(id);
        }

        public int GetirIsciElaveEdilmeyiGozleyenIsSayi()
        {
            return _taskDal.GetirIsciElaveEdilmeyiGozleyenIsSayi();
        }

        public int GetirIsSayiTamamlananAppUserIdile(int id)
        {
            return _taskDal.GetirIsSayiTamamlananAppUserIdile( id);
        }

        public int GetirIsSayiTamamlanmasiGerekenAppUserIdile(int id)
        {
           return _taskDal.GetirIsSayiTamamlanmasiGerekenAppUserIdile(id);
        }

        public int GetirIsTamamlanmisSayi()
        {
            return _taskDal.GetirIsTamamlanmisSayi();
        }

        public Is GetirRaporlarileId(int id)
        {
          return _taskDal.GetirRaporlarileId(id);
        }

        public Is GetirVaciblikIdIle(int id)
        {
         return  _taskDal.GetirVaciblikIdIle(id);
        }

        public List<Is> GetirVaciblikTamamlanmayan()
        {
            return _taskDal.GetirVaciblikTamamlanmayan();
        }

        public void Guncelle(Is tablo)
        {
            _taskDal.Guncelle(tablo);
        }

        public void Kaydet(Is tablo)
        {
            _taskDal.Kaydet(tablo);
        }

        public void Sil(Is tablo)
        {
            _taskDal.Sil(tablo);
        }

    }
}
