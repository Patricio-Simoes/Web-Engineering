using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FP_02_01_2022_2023.Data;
using FP_02_01_2022_2023.Models;
using Microsoft.AspNetCore.Authorization;

namespace FP_02_01_2022_2023.Controllers
{
    public class BolsasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BolsasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Lista()
        {
            return View(await _context.Bolsas.ToListAsync());
        }

        public async Task<string> Detalhes(int? id)
        {
            if (id == null)
            {
                return "";
            }

            var bolsaInvestigacao = await _context.Bolsas
                .FirstOrDefaultAsync(m => m.id == id);
            if (bolsaInvestigacao == null)
            {
                return "";
            }

            return "" + bolsaInvestigacao.remuneracao + "€ durante "
                + bolsaInvestigacao.duracao + " meses";
        }

        [Authorize]
        public IActionResult Adiciona()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adiciona([Bind("id,titulo,area,duracao,remuneracao")] BolsaInvestigacao bolsaInvestigacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bolsaInvestigacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bolsaInvestigacao);
        }
    }
}
