using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP_10.Filters;
using TP_10.Models;

namespace TP_10.Controllers
{
    [DailyMaintenanceFilter(From = new[] {10,10,0}, To = new[] {23,59,59})]
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