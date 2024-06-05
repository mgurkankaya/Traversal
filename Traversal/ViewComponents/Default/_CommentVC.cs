using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _CommentVC:ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id)
        {
           var value = commentManager.TGetDestinationById(id);
            return View(value);
        }
    }
}
