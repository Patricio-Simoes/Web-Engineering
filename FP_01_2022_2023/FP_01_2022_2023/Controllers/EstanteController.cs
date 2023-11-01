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
    public class EstanteController : Controller
    {
        private readonly FP_01_2022_2023Context _context;
        private readonly IHostEnvironment _he;

        public EstanteController(FP_01_2022_2023Context context, IHostEnvironment he)
        {
            _context = context;
            _he = he;
        }

        public async Task<IActionResult> Index()
        {
              return _context.Jogo != null ? 
                          View(await _context.Jogo.ToListAsync()) :
                          Problem("Entity set 'FP_01_2022_2023Context.Jogo'  is null.");
        }

        public IActionResult Introduzir()
        {
            return View();
        }

        // Introduz um novo jogo na estante.
        // (Não há maneira de remover jogos introduzidos).
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Introduzir([Bind("id,nome,descricao,foto,pontuacao,estado")] Jogo jogo, IFormFile foto)
        {
            if (ModelState.IsValid)
            {
                if(foto != null)
                {
                    string destination = Path.Combine(_he.ContentRootPath, "wwwroot/Imagens/", Path.GetFileName(foto.FileName));
                    using (FileStream fs = new FileStream(destination, FileMode.Create))
                        foto.CopyTo(fs);
                    jogo.foto = foto.FileName;
                }
                _context.Add(jogo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jogo);
        }

        public async Task<IActionResult> Aumentar(int id)
        {
            var jogo = _context.Jogo.Single(x => x.id == id);
            jogo.pontuacao++;
            _context.Jogo.Update(jogo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Diminuir(int id)
        {
            var jogo = _context.Jogo.Single(x => x.id == id);
            jogo.pontuacao--;
            _context.Jogo.Update(jogo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remover(int id)
        {
            var jogo = _context.Jogo.Single(x => x.id == id);
            jogo.estado = !jogo.estado;
            _context.Jogo.Update(jogo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
