using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    [AllowAnonymous]
    public class ErrorPages : Controller
    {
        public IActionResult Error404(int code)
        {

            return View();
        }
    }
}
