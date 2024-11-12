using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class GuideController(IGuideService guideService) : Controller
	{
		public IActionResult Index()
		{
			var value = guideService.TGetList();
			return View(value);
        }

		public IActionResult AddGuide()
        {
         

            return View();
		}

		[HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            guideService.TAdd(guide);
			return RedirectToAction("Index");
        }

        public IActionResult UpdateGuide(int id)
        {
            var value = guideService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateGuide(Guide guide)
        {
           guideService.TUpdate(guide);
           return RedirectToAction("Index");
        }

        public IActionResult DeleteGuide(int id)
        {
            var value = guideService.TGetById(id);
            guideService.TDelete(value);
            return RedirectToAction("Index");
        }
       
        public IActionResult ChangeToTrue(int id)
        {
            guideService.TChangeToTrueByGuide(id);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeToFalse(int id)
        {
            guideService.TChangeToFalseByGuide(id);
            return RedirectToAction("Index");
        }
    }
}