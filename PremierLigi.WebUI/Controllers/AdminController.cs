using Microsoft.AspNetCore.Mvc;

namespace PremierLigi.WebUI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}