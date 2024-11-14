using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Traversal.Areas.Admin.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AnnouncementController(IAnnouncementService _announcementService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var value = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.TGetList());
            return View(value);
        }
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDTO model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TAdd(new Announcement()
                {
                    Title = model.Title,
                    Content = model.Content,
                    AnnouncementDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
               
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            var value = _announcementService.TGetById(id);
            _announcementService.TDelete(value);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateAnnouncement(int id)
        {
            var value = _mapper.Map<AnnouncementUpdateDTO>(_announcementService.TGetById(id));
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TUpdate(new Announcement
                {
                    AnnouncementId = model.AnnouncementId,
                    Title = model.Title,
                    Content = model.Content,
                    AnnouncementDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            
            return View();
        }
    }

}