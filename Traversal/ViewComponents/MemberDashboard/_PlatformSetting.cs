﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.MemberDashboard
{
    public class _PlatformSetting : ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
           return View();
        }
    }
}
