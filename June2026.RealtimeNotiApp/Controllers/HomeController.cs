using June2026.RealtimeNotiApp.Hubs;
using June2026.RealtimeNotiApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace June2026.RealtimeNotiApp.Controllers
{
    public class HomeController : Controller
    {
        private static int count = 0;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHubContext<NotificationHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Count()
        {
            count++;
            await _hubContext.Clients.All.SendAsync("NotiEvent", count);
            return Redirect("index");
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
