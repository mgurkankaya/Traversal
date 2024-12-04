using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace Traversal.Controllers
{
    [AllowAnonymous]

    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        public PartialViewResult AddComment()
        {
            //var value = await _userManager.FindByNameAsync(User.Identity.Name);
            //ViewBag.userId = value.Id;
            //ViewBag.destId = id;
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.CDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            comment.CUser = "dene";
            comment.State = true;
            commentManager.TAdd(comment);
            return RedirectToAction("Index","Destination");
        }
    }
}
