using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
        public void ContactUsStatusChangeToFalse(int id)
        {
            Context context = new Context();
            var value = context.ContactUses.Find(id);
            value.ContactUsStatus = false;
            context.Update(value);
            context.SaveChanges();
        }

        public void ContactUsStatusChangeToTrue(int id)
        {
            Context context = new Context();
            var value = context.ContactUses.Find(id);
            value.ContactUsStatus = true;
            context.Update(value);
            context.SaveChanges();
        }

        public List<ContactUs> GetListContactUsByFalse()
        {
            using (var context = new Context())
            {
                var value = context.ContactUses.Where(x=>x.ContactUsStatus==false).ToList();
                return value;
            }
        }

        public List<ContactUs> GetListContactUsByTrue()
        {
            using (var context = new Context())
            {
                var value = context.ContactUses.Where(x => x.ContactUsStatus == true).ToList();
                return value;
            }
        }
    }
}
