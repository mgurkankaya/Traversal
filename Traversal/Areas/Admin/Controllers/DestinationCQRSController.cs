using Microsoft.AspNetCore.Mvc;
using Traversal.CQRS.Handlers.DestinationHandlers;
using Traversal.CQRS.Queries.DestinationQueries;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
        private readonly GetDestinationByIdQueryHandler _getDestinationByIdQueryHandler;

        public DestinationCQRSController(GetDestinationByIdQueryHandler getDestinationByIdQueryHandler, GetAllDestinationQueryHandler getAllDestinationQueryHandler)
        {
            _getDestinationByIdQueryHandler = getDestinationByIdQueryHandler;
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
        }

        public IActionResult Index()
        {
            var values = _getAllDestinationQueryHandler.Handle();
            return View(values);
        }

        public IActionResult GetDestination(int id)
        {
            var value = _getDestinationByIdQueryHandler.Handle(new GetDestinationByIdQuery(id));
            return View(value);
        }
    }
}
