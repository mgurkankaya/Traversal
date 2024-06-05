using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _SliderVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
         

            return View();
        }
    }
}
