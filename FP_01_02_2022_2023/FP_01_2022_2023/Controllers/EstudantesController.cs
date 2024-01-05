using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FP_01_2022_2023.Data;
using FP_01_2022_2023.Models;

namespace FP_01_2022_2023.Controllers
{
    public class EstudantesController : Controller
    {
        private readonly FP_01_2022_2023Context _context;

        public EstudantesController(FP_01_2022_2023Context context)
        {
            _context = context;
        }

        // GET: Estudantes
        public async Task<IActionResult> Listar()
        {
            return View(await _context.Aluno.OrderBy(x => x.date).ToListAsync());
        }

        // GET: Estudantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aluno == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .FirstOrDefaultAsync(m => m.numero == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        public IActionResult Registo()
        {
            return View();
        }

        // Regista novos estudantes e verifica se já não existem dados iguais na BD.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registo([Bind("numero,email,nome,date")] Aluno aluno)
        {
            // Verifica se já existe um número associado.
            if (_context.Aluno.Any(x => x.numero == aluno.numero))
                ModelState.AddModelError("numero", "Número já existe, escolha outro");
            // Verifica se já existe um e-mail associado.
            if (_context.Aluno.Any(x => x.email == aluno.email))
                ModelState.AddModelError("email", "E-mail já existe, escolha outro");
            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listar));
            }
            return View(aluno);
        }

        // GET: Estudantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aluno == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // POST: Estudantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("numero,email,nome, date")] Aluno aluno)
        {
            if (id != aluno.numero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.numero))
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
            return View(aluno);
        }

        // GET: Estudantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aluno == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .FirstOrDefaultAsync(m => m.numero == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Estudantes/Delete/5
        public async Task<IActionResult> Remover(int id)
        {
            if (_context.Aluno == null || _context.Aluno == null)
                return NotFound();
            var aluno = await _context.Aluno.FirstOrDefaultAsync(x => x.numero == id);
            if (aluno == null)
                return NotFound();
            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        private bool AlunoExists(int id)
        {
          return (_context.Aluno?.Any(e => e.numero == id)).GetValueOrDefault();
        }
    }
}
