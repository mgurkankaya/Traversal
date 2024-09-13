using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class UserController(IAppUserService appUserService, IReservationService reservationService) : Controller
    {
        public IActionResult Index()
        {
            var values = appUserService.TGetList();
            return View(values);
        }

        

        public IActionResult DeleteUser(int id)
        {
            var values = appUserService.TGetById(id);
            appUserService.TDelete(values);
            return RedirectToAction("Index");
        } 
        
        public IActionResult UpdateUser(int id)
        {
           var value = appUserService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateUser(AppUser appUser)
        {
            appUserService.TUpdate(appUser);
            return RedirectToAction("Index");
        }

        public IActionResult CommentUser(int id)
        {
            appUserService.TGetList();
            return View();
        } 
        public IActionResult ReservationUser(int id)
        {
            var value = reservationService.GetListWithReservationByAccepted(id);
            return View(value);
        }
    }
}
