using Microsoft.AspNetCore.Mvc;

namespace TP_10.Controllers
{
    public class SecurityController : Controller
    {
        public IActionResult Maintenance()
        {
            HttpContext.Response.StatusCode = 405;
            return View();
        }
    }
}
