using Microsoft.AspNetCore.Mvc;

namespace Mysite.Presentation.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
