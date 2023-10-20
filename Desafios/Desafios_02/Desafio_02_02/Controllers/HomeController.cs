using Desafio_02_02.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Desafio_02_02.Controllers
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

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(IFormCollection collection)
        {
            if (collection["confirmarEmail"] != collection["email"])
            {
                ModelState.AddModelError("confirmarEmail", "ERRO :: Os campos de E-mail não são iguais!");
                TempData["username"] = collection["username"];
                TempData["email"] = collection["email"];
                TempData["confirmarEmail"] = collection["confirmarEmail"];
                return View();
            }
            if (collection["terms"] == "false")
            {
                ModelState.AddModelError("terms", "ERRO :: Tem de aceitar os Termos & Condições!");
                TempData["username"] = collection["username"];
                TempData["email"] = collection["email"];
                TempData["confirmarEmail"] = collection["confirmarEmail"];
                return View();

            }
            else if (!ModelState.IsValid)
                return View();
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}