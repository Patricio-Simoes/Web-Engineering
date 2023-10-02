using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_02__2.Controllers
{
    public class UtilizadorController : Controller
    {
        // GET: UtilizadorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UtilizadorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UtilizadorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UtilizadorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: UtilizadorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UtilizadorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UtilizadorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UtilizadorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
