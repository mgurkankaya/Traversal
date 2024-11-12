using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CityController(IDestinationService _destinationService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }

        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            if (ModelState.IsValid)
            {
                destination.Status = true;
                destination.ImageUrl = "#";
                destination.Description = "#";
                destination.CoverImage = "#";
                destination.Details1 = "#";
                destination.Details2 = "#";
                destination.ImageUrl2 = "#";
                _destinationService.TAdd(destination);
                var value = JsonConvert.SerializeObject(destination);
                return Json(value);
            }
            return BadRequest("Model doğrulama hatası");
        }

        public IActionResult GetById(int DestinationId)
        {
         
            var values = _destinationService.TGetById(DestinationId);
            if (values == null)
            {
                return NotFound("Aradığınız ID'ye ait bir şehir bulunamadı.");
            }
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }

        [HttpPost]
        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.TGetById(id);
            _destinationService.TDelete(values);
            return NoContent();
        }
        [HttpPost]
        public IActionResult UpdateCity(Destination destination)
        {
            // Güncellenecek kaydı veritabanından getirin
            var existingDestination = _destinationService.TGetById(destination.DestinationId);
            if (existingDestination == null)
            {
                return NotFound("Güncellenmek istenen şehir bulunamadı.");
            }

            // Sadece gelen verileri güncelleyin
            existingDestination.City = destination.City;
            existingDestination.DayNight = destination.DayNight;

            // Diğer alanları olduğu gibi koruyun
            _destinationService.TUpdate(existingDestination);

            var result = JsonConvert.SerializeObject(existingDestination);
            return Json(result);
        }
    }
}