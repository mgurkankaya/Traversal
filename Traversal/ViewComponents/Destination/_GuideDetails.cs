using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Destination
{
    public class _GuideDetails:ViewComponent
    {
        private readonly IGuideService _guideService;

        public _GuideDetails(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _guideService.TGetById(6);
            return View(value);
        }

    }
}
