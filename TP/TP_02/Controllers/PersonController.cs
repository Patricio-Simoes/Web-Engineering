using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_02.Models;

namespace TP_02.Controllers
{
    public class PersonController : Controller
    {
        // GET: PersonController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: PersonController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(collection["name"]) == true)
        //            ModelState.AddModelError("name", "Mandatory Field");
        //        if (string.IsNullOrEmpty(collection["age"]) == true)
        //            ModelState.AddModelError("age", "Mandatory Field");
        //        else
        //        {
        //            int aux;
        //            try
        //            {
        //                aux = int.Parse(collection["age"]);
        //                if (aux < 18 || aux > 100)
        //                    ModelState.AddModelError("age", "Age should be between 18 and 100");
        //            }
        //            catch(FormatException)
        //            {
        //                ModelState.AddModelError("age", "Must indicate a integer number");
        //            }
        //        }
        //        if (ModelState.IsValid)
        //        {
        //            TempData["values"] = collection["name"] + "[" + collection["age"] + "]";
        //            return RedirectToAction(nameof(Index));
        //        }
        //        else
        //            return View();
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person newPerson)
        {
            if(ModelState.IsValid)
            {
                TempData["values"] = newPerson.Name + " [" + newPerson.Age + "]";
                return RedirectToAction(nameof(Index));
            }
            else
                return View();
        }
    }
}
