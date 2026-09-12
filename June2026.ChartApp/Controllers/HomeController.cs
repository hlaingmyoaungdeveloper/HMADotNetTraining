using June2026.ChartApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace June2026.ChartApp.Controllers
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
            List<int> series = [42, 23, 15, 12, 8];
            List<string> labels = ["Organic Search", "Direct", "Social", "Referral", "Email"];
            ViewData["Series"] = series;
            ViewData["Labels"] = labels;
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
