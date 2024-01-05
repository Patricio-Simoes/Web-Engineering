using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP_11.Models;

namespace TP_11.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string TestAjaxForm(string Text)
        {
            return "<br>Received " + Text + " at <strong>" + DateTime.Now + "</strong>";
        }
        public string TestAjaxLink()
        {
            // 2s de espera.
            System.Threading.Thread.Sleep(2000);
            return "executed at <strong> " + DateTime.Now + "</strong>";
        }
    }
}
