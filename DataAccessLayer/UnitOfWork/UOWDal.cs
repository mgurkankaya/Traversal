using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UOWDal(Context _context) : IUOWDal
    {
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
