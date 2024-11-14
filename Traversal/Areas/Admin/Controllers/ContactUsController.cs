using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ContactUsController(IContactUsService _contactUsService) : Controller
    {
        public IActionResult Index()
        {
            var value = _contactUsService.TGetListContactUsByTrue();
            ViewBag.inboxCount = _contactUsService.TGetList().Count(x=>x.ContactUsStatus==true);
            ViewBag.trashCount = _contactUsService.TGetList().Count(x=>x.ContactUsStatus==false);
            return View(value);
        }

        public IActionResult Trash()
        {
            var value = _contactUsService.TGetListContactUsByFalse();
            ViewBag.inboxCount = _contactUsService.TGetList().Count(x => x.ContactUsStatus == true);
            ViewBag.trashCount = _contactUsService.TGetList().Count(x => x.ContactUsStatus == false);
            return View(value);
        }

        public IActionResult ChangeToTrue(int id)
        {
            _contactUsService.TContactUsStatusChangeToTrue(id);
            return RedirectToAction("Trash");
        }

        public IActionResult ChangeToFalse(int id)
        {
            _contactUsService.TContactUsStatusChangeToFalse(id);
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            var value =_contactUsService.TGetById(id);
            return View(value);
        }

    }
}