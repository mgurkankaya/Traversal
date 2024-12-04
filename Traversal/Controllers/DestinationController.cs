using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    [AllowAnonymous]

    public class DestinationController(UserManager<AppUser> _userManager) : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }

        public async Task<IActionResult> DestinationDetails(int id)
        {
            ViewBag.i = id;
            ViewBag.destId = id;
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userId = value.Id;
            var values = destinationManager.TGetDestinationWidthGuide(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult DestinationDetails(Destination destination)
        {
            return View();
        }
    }
}
