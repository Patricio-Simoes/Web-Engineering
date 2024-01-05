using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP_11.Data;
using TP_11.Models;

namespace TP_11.Controllers
{
    public class AdminController : Controller
    {
        private readonly TP_11Context _context;

        public AdminController(TP_11Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Person.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        public IActionResult Create(string NewName)
        {
            Person newP = new Person();
            newP.Name = NewName;
            _context.Person.Add(newP);
            _context.SaveChanges();

            return PartialView("Listing", _context.Person);
        }

        public IActionResult Edit(int id)
        {
            Person a = _context.Person.SingleOrDefault(x => x.Id == id);
            return PartialView("Edit", a);
        }
        [HttpPost]
        public string Edit(int id, Person p)
        {
            _context.Update(p);
            _context.SaveChanges();
            return p.Name;
        }
        public IActionResult Delete(int id)
        {
            Person p=_context.Person.SingleOrDefault(x => x.Id == id);
            _context.Person.Remove(p);
            _context.SaveChanges();

            return PartialView("Listing", _context.Person);
        }
    }
}
