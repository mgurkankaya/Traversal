using BusinessLayer.Abstract.AbstractUOW;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete.ConcreteUOW
{
    public class AccoountManager(IAccountDal _accountDal, IUOWDal _uOWDal) : IAccountService
    {
        public Account TGetByID(int id)
        {
            return _accountDal.GetByID(id);
           
        }

        public void TInsert(Account t)
        {
            _accountDal.Insert(t);
            _uOWDal.Save();
        }

        public void TMultiUpdate(List<Account> t)
        {
            _accountDal.MultiUpdate(t);
            _uOWDal.Save();
        }

        public void TUpdate(Account t)
        {
            _accountDal.Update(t);
            _uOWDal.Save();
        }
    }
}
