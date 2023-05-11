using Microsoft.AspNetCore.Mvc;

namespace MySite.Presentation.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
