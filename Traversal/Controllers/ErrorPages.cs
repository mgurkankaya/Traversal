using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    public class ErrorPages : Controller
    {
        public IActionResult Error404(int code)
        {

            return View();
        }
    }
}
