using Microsoft.AspNetCore.Mvc;

namespace TP_02.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection formData)
        {
            // Action used to process the form submited
            ViewData["text_inserted"] = formData["name"];
            ViewData["other_text_inserted"] = formData["age"];

            return View("Index2");
        }
    }
}
