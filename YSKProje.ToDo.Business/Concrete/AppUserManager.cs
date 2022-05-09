using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {

        IAppUserDal _appUserDal;
        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }
        public List<AppUser> GetirAdminOlmayanlar()
        {
            return _appUserDal.GetirAdminOlmayanlar();
        }

        public List<AppUser> GetirAdminOlmayanlar(out int toplamSeyife, string axtarilacaqsoz, int aktivseyife )
        {
          return  _appUserDal.GetirAdminOlmayanlar(out toplamSeyife, axtarilacaqsoz,aktivseyife);
        }

       

        public List<DualHelper> GetirEnCoxIsdeIsleyenIstifadeciler()
        {
            return _appUserDal.GetirEnCoxIsdeIsleyenIstifadeciler();
        }

        public List<DualHelper> GetirEnCoxIsGormusIstifadeciler()
        {
            return _appUserDal.GetirEnCoxIsGormusIstifadeciler();
        }
    }
}
