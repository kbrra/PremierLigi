using Microsoft.AspNetCore.Mvc;
using PremierLigi.WebUI.Models;
using System.Diagnostics;

namespace PremierLigi.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Standings()
        {
            return View();
        }

        public IActionResult Fixtures()
        {
            return View();
        }

        public IActionResult Teams()
        {
            return View();
        }

        public IActionResult MatchDetail(int id)
        {
            ViewBag.MatchId = id;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}