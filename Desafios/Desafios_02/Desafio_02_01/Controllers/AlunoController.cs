using Desafio_02_01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_02_01.Controllers
{
	public class AlunoController : Controller
	{
		// GET: AlunoController
		public ActionResult Index()
		{
			return View();
		}

		// GET: AlunoController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: AlunoController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: AlunoController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Aluno newAluno)
		{
			if(ModelState.IsValid)
			{
				TempData["numero"] = newAluno.numero;
				TempData["nome"] = newAluno.nome;
				return RedirectToAction(nameof(Index));
			}
			else
			{
				return View();
			}
		}

		// GET: AlunoController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: AlunoController/Edit/5
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

		// GET: AlunoController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: AlunoController/Delete/5
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
