using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Concrete
{
    public class VaciblikManager : IVaciblikService
    {


        public readonly IVaciblikDal _vaciblikDal;
        public VaciblikManager(IVaciblikDal vaciblikDal )
        {
            _vaciblikDal = vaciblikDal;
           
        }
        public List<Vaciblik> GetirHepsi()
        {
            return _vaciblikDal.GetirHepsi();
        }

        public Vaciblik GetirIdile(int id)
        {
            return _vaciblikDal.GetirIdile(id);
        }

        public void Guncelle(Vaciblik tablo)
        {
            _vaciblikDal.Guncelle(tablo);
        }

        public void Kaydet(Vaciblik tablo)
        {
            _vaciblikDal.Kaydet(tablo);
        }

        public void Sil(Vaciblik tablo)
        {
            _vaciblikDal.Sil(tablo);
        }
    }
}
