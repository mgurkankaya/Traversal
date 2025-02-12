﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.MemberDashboard
{
    public class _LastDestinations(IDestinationService _destinationService):ViewComponent
    { 
        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetLast4Destinations();
            return View(values);
        }
    }
}
