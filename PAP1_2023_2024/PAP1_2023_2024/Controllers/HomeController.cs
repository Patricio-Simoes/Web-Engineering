using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PAP1_2023_2024.Data;
using PAP1_2023_2024.Models;

namespace PAP1_2023_2024.Controllers
{
    public class HomeController : Controller
    {
        private readonly PAP1_2023_2024Context _context;

        public HomeController(PAP1_2023_2024Context context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index(bool naoFechados = false)
        {
            if(naoFechados == true)
                return View(await _context.Registo.Where(x => x.saida == null).ToListAsync());
            else
                return View(await _context.Registo.ToListAsync());
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Registo == null)
            {
                return NotFound();
            }
            var registo = await _context.Registo.FindAsync(id);
            if (registo == null)
            {
                return NotFound();
            }
            return View(registo);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,username,entrada,saida")] Registo registo)
        {
            if (id != registo.id)
            {
                return NotFound();
            }
            if(registo.saida <= registo.entrada)
            {
                ModelState.AddModelError("saida", "A data inserida não é válida");
                return View(registo); 

            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistoExists(registo.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(registo);
        }

        // GET: Home/Delete/5

        private bool RegistoExists(int id)
        {
          return (_context.Registo?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
