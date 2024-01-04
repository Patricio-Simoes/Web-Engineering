using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP_08.Models;

namespace TP_08.Controllers
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

        public IActionResult AddCookies()
        {
            // Cookie de sess�o.
            HttpContext.Response.Cookies.Append("Test1", "Value1");
            // Cookie persistente por 10 seg.
            HttpContext.Response.Cookies.Append("Test2", "Value2",
                new CookieOptions() { Expires = DateTime.Now.AddSeconds(10)});
            // Cookie persistente por 1 dia.
            HttpContext.Response.Cookies.Append("Test3", "Value3",
                new CookieOptions() { Expires = DateTime.Now.AddDays(1)});
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCookies()
        {
            // Apaga todos os cookies da resposta e do cliente.
            foreach(var item in HttpContext.Request.Cookies.Keys)
            {
                HttpContext.Response.Cookies.Delete(item);
            }
            return RedirectToAction("Index");
        }

        // O objetivo desta fun��o � criar vari�veis que 'transportem' dados numa sess�o atrav�s de um cookie de sess�o definido no ficheiro 'program.cs'.
        // No caso, na sess�o '.AspNetCore.Session'.
        public IActionResult AddSessionVariables()
        {
            // As vari�veis podem assumir valores de tipo string, int ou byte array.
            HttpContext.Session.SetString("StringValue", "Text variable value");
            HttpContext.Session.SetInt32("IntegerValue", 100);
            // Um cookie de sess�o, '.AspNetCore.Session', (definido no ficheiro 'program.cs'), ser� automaticamente criado e enviado para o cliente.

            return RedirectToAction("Index");
        }

        // O objetivo desta fun��o � apahar todas as vari�veis guardadas na sess�o.
        // Esta fun��o n�o apaga a sess�o, apenas as vari�veis a si associadas.
        public IActionResult DeleteSessionVariables()
        {
            foreach(var item in HttpContext.Session.Keys)
            {
                HttpContext.Session.Remove(item);
            }
            return RedirectToAction("Index");
        }

        // O objetivo desta fun��o � apagar a sess�o e como consequ�ncia, todas as vari�veis nela guardadas.
        public IActionResult DeleteSession()
        {
            // (Ver defini��o do nome da sess�o no ficheiro 'program.cs'.)
            HttpContext.Response.Cookies.Delete(".AspNetCore.Session");
            return RedirectToAction("Index");
        }
    }
}
