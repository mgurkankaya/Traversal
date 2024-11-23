using MediatR;
using Microsoft.AspNetCore.Mvc;
using Traversal.CQRS.Commands.GuideCommands;
using Traversal.CQRS.Queries.GuideQueries;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class GuideMediatRController(IMediator _mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var value = await _mediator.Send(new GetAllGuideQuery());
            return View(value);
        }

        public async Task<IActionResult> GetGuide(int id)
        {
            var value = await _mediator.Send(new GetGuideByIDQuery(id));
            return View(value);
        }

        public IActionResult AddGuide()
        {
           return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGuide(CreateGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}
