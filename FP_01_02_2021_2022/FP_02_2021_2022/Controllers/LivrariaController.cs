using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FP_02_2021_2022.Models;

namespace FP_02_2021_2022.Controllers
{
    public class LivrariaController : Controller
    {
        private readonly EW_2021_PAP1_DB_alXXXXX _context;
        private readonly IHostEnvironment _he;

        public LivrariaController(EW_2021_PAP1_DB_alXXXXX context, IHostEnvironment he)
        {
            _context = context;
            _he = he;
        }

        public async Task<IActionResult> Lista()
        {
              return _context.Livro != null ? 
                          View(await _context.Livro.ToListAsync()) :
                          Problem("Entity set 'EW_2021_PAP1_DB_alXXXXX.Livro'  is null.");
        }

        public IActionResult Inserir()
        {
            return View();
        }

        // Insere um novo Livro.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inserir([Bind("titulo,autores,editora,isbn,capa,contracapa")] Livro livro, IFormFile capa, IFormFile contracapa)
        {
            if (ModelState.IsValid)
            {
                if (capa != null)
                {
                    string destination = Path.Combine(_he.ContentRootPath, "wwwroot/Imagens", Path.GetFileName(capa.FileName));
                    using (FileStream fs = new FileStream(destination, FileMode.Create))
                        capa.CopyTo(fs);
                    livro.capa = capa.FileName;
                }
                if (contracapa != null)
                {
                    string destination = Path.Combine(_he.ContentRootPath, "wwwroot/Imagens", Path.GetFileName(contracapa.FileName));
                    using (FileStream fs = new FileStream(destination, FileMode.Create))
                        contracapa.CopyTo(fs);
                    livro.contracapa = contracapa.FileName;
                }
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Lista));
            }
            return View(livro);
        }

        public async Task<IActionResult> Remover(string id)
        {
            if (_context.Livro == null)
                return Problem("Entity set 'EW_2021_PAP1_DB_alXXXXX.Livro'  is null.");

            var livro = await _context.Livro.FindAsync(id);

            if (livro == null)
                return NotFound();

            if ((livro.capa != null))
            {
                string destination = Path.Combine(_he.ContentRootPath, "wwwroot/Imagens", livro.capa);
                if (System.IO.File.Exists(destination))
                    System.IO.File.Delete(destination);
            }

            if ((livro.contracapa != null))
            {
                string destination = Path.Combine(_he.ContentRootPath, "wwwroot/Imagens", livro.contracapa);
                if (System.IO.File.Exists(destination))
                    System.IO.File.Delete(destination);
            }

            _context.Livro.Remove(livro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        private bool LivroExists(string id)
        {
          return (_context.Livro?.Any(e => e.titulo == id)).GetValueOrDefault();
        }
    }
}
