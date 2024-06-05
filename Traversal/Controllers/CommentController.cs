using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        public PartialViewResult AddComment(int id)
        {
            ViewBag.i = id;
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.CDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            comment.State = true;
            commentManager.TAdd(comment);
            return RedirectToAction("Index","Destination");
        }
    }
}
