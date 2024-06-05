using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _TestimonialVC:ViewComponent
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
        public IViewComponentResult Invoke()
        {
            var value = testimonialManager.TGetList();
            return View(value);
        }

    }
}
