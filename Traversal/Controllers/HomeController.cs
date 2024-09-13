using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using System.Diagnostics;
using Traversal.Models;

namespace Traversal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index sayfas� �a��r�ld�.");
            return View();
        }

        public IActionResult Privacy()
        {
            DateTime d =Convert.ToDateTime( DateTime.Now.ToLongDateString());
            _logger.LogInformation(d + "Privacy sayfas� �a��r�ld�.");
            return View();
        }
        public IActionResult Test()
        {
            _logger.LogInformation("Test sayfas� �a��r�ld�.");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
