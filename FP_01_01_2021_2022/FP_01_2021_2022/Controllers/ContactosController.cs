using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FP_01_2021_2022.Data;
using FP_01_2021_2022.Models;

namespace FP_01_2021_2022.Controllers
{
    public class ContactosController : Controller
    {
        private readonly FP_01_2021_2022Context _context;

        public ContactosController(FP_01_2021_2022Context context)
        {
            _context = context;
        }

        // GET: Contactos
        public async Task<IActionResult> Lista(bool? flag = false)
        {
            if (flag == true)
                return View(await _context.Contacto.Where(x => x.amigo == true).ToListAsync());
            return View(await _context.Contacto.ToListAsync());
        }

        // GET: Contactos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contacto == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto
                .FirstOrDefaultAsync(m => m.id == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        public IActionResult Registar()
        {
            return View();
        }

        // Regista um novo contacto.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registar([Bind("id,email,name,nickname,amigo")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Lista));
            }
            return View(contacto);
        }

        // GET: Contactos/Edit/5
        public async Task<IActionResult> Alterar(int? id)
        {
            if (id == null || _context.Contacto == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        // Altera as informações de um amigo.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar(int id, [Bind("id,email,name,nickname,amigo")] Contacto contacto)
        {
            if (id != contacto.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoExists(contacto.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["Update"] = "Contacto '" + contacto.nickname + "' atualizado com sucesso!";
                return RedirectToAction(nameof(Lista));
            }
            return View(contacto);
        }

        private bool ContactoExists(int id)
        {
          return (_context.Contacto?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
