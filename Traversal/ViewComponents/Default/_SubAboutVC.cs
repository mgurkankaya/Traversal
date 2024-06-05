using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _SubAboutVC:ViewComponent
    {
        SubAboutManager subAboutManager = new SubAboutManager(new EfSubAboutDal());
        public IViewComponentResult Invoke()
        {
            var value = subAboutManager.TGetList();
            return View(value);
        }
    }
}
