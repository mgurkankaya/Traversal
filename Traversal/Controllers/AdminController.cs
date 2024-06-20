using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    public class AdminController : Controller
    {
        public PartialViewResult PartialHaeder()
        {
            return PartialView();
        }

        public PartialViewResult PartialSideBar()
        {
            return PartialView();
        }   
        
        public PartialViewResult PartialNavBar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
    }
}
