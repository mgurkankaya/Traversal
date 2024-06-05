using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService //IAboutService miras alınır. Oradan IGeneric içerisindeki T parametresi ile About tablosuna erişir.
    {
        IAboutDal _aboutDal; //Data Access Layer'a eriş.

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public About GetById(int id)
        {
            throw new NotImplementedException();
        }



        public void TAdd(About t)
        {
            _aboutDal.Insert(t);
        }

        public void TDelete(About t)
        {
            _aboutDal.Delete(t);
        }

        public About TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> TGetList()
        {
            return _aboutDal.GetList(); //DAL --> Abstract --> IGenericDal'a erişir ve GetList metodunu çağırır.
        }

        public void TUpdate(About t)
        {
            _aboutDal.Update(t);
        }
    }
}
