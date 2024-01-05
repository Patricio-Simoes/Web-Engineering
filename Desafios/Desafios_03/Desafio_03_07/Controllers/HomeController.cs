using Desafio_03_07.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Diagnostics;

namespace Desafio_03_07.Controllers
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
            var fileList = files.GetFiles(_he);
            return View(fileList);
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
        public IActionResult Upload(Document document) {
            if(ModelState.IsValid)
            {
                string destination = Path.Combine(_he.ContentRootPath, "wwwroot/Documents/", Path.GetFileName(document.file.FileName));
                using (FileStream fs = new FileStream(destination, FileMode.Create))
                {
                    document.file.CopyTo(fs);
                }
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