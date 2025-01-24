using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    [AllowAnonymous]
    public class GuideController(IGuideService _guideService) : Controller
    {
        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }
    }
}
