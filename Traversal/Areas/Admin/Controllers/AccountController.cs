using BusinessLayer.Abstract.AbstractUOW;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Traversal.Areas.Admin.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AccountController(IAccountService _accountService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountViewModel model)
        {
            var valueSender = _accountService.TGetByID(model.SenderId);
            var valueReceiver = _accountService.TGetByID(model.ReceiverId);
            valueSender.Balance -= model.Amount;
            valueReceiver.Balance += model.Amount;
            List<Account> modifiedAccount = new List<Account>()
            {
                valueSender,
                valueReceiver

            };
            _accountService.TMultiUpdate(modifiedAccount);
            return View();
        }
    }
}
