using Microsoft.AspNetCore.Mvc;

namespace TP_10.Controllers
{
    public class TestCacheController : Controller
    {
        [ResponseCache(Duration = 20, Location = ResponseCacheLocation.Client)]
        public IActionResult onClient()
        {
            return View();
        }

        [ResponseCache(Duration = 40, Location = ResponseCacheLocation.Any)]
        public IActionResult onDownStream()
        {
            return View();
        }
        [ResponseCache(CacheProfileName = "TestCacheProfile")]
        public IActionResult WithHeaders()
        {
            return View();
        }
    }
}
