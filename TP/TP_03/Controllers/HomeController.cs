using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Diagnostics;
using TP_03.Models;

namespace TP_03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostEnvironment _he;

        public HomeController(ILogger<HomeController> logger, IHostEnvironment he)
        {
            _logger = logger;
            _he = he;
        }

        public IActionResult Index()
        {
            DocFiles files = new DocFiles();
            return View(files.GetFiles(_he));
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
        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Upload(IFormFile Name)
        {
            if(ModelState.IsValid)
            {
                string destination = Path.Combine(_he.ContentRootPath,
                    "wwwroot/Documents/", Path.GetFileName(Name.FileName));
                FileStream fs=new FileStream(destination, FileMode.Create);
                Name.CopyTo(fs);
                fs.Close();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Download(string id)
        {
            string pathFile = Path.Combine(_he.ContentRootPath, "wwwroot/Documents/", id);
            byte[] fileBytes = System.IO.File.ReadAllBytes(pathFile);
            string? mimeType;
            new FileExtensionContentTypeProvider().TryGetContentType(id, out mimeType);
            return File(fileBytes, mimeType);
        }
    }
}