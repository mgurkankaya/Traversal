using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class DestinationController(IDestinationService destinationService) : Controller
    {
        
        public IActionResult Index()
        {
            var values = destinationService.TGetList();
            return View(values);
        }

        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            destinationService.TAdd(destination);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestination(int id) 
        {
           var values = destinationService.TGetById(id);
            destinationService.TDelete(values);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateDestination(int id)
        {
            var values = destinationService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            destinationService.TUpdate(destination);
            return RedirectToAction("Index");
        }


    }
}
