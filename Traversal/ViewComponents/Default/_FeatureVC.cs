using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _FeatureVC:ViewComponent
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        public IViewComponentResult Invoke()
        {
            var value = featureManager.TGetList();
            return View(value);
        }
    }
}
