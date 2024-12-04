using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    
    public class _CommentVC : ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        Context context = new Context();
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.commentCount = context.Comments.Where(x => x.DestinationId == id).Count();
            var value = commentManager.TGetListCommentWithDestinationandUser(id);
            return View(value);
        }
    }
}
