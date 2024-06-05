using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _CounterVC:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var c = new Context();
            ViewBag.v1 = c.Destinations.Count();
            ViewBag.v2 = c.Guides.Count();
            ViewBag.v3 = "288";
            return View();
        }
    }
}
