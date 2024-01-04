using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP_08.Data;
using TP_08.Models;

namespace TP_08.Controllers
{
    public class UserController : Controller
    {
        private readonly TP_08Context _context;

        public UserController(TP_08Context context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        public IActionResult login()
        {
            return View();
        }

        // Esta função está responsável por identificar se um utilizador que se tenta autenticar, está registado e possui os seus dados na BD.
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                User u = _context.User.SingleOrDefault(u => u.Username == username && u.Password == password);
                if (u == null)
                    ModelState.AddModelError("username", "Username or password are wrong!");
                else
                {
                    // O utilizador é autenticado, inicia sessão e é criada uma variável de sessão 'user' para identificar o utilizador entre pedidos.
                    HttpContext.Session.SetString("user", username);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        
        // Esta função apaga o cookie de sessão '.User.Session' e redireciona o utilizador para a página de login, efetuando assim uma ação de logout.
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete(".User.Session");
            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Username,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                // O utilizador é registado, inicia sessão e é criada uma variável de sessão 'user' para identificar o utilizador entre pedidos.
                HttpContext.Session.SetString("user", user.Username);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public IActionResult Preferences()
        {
            ViewBag.mode = HttpContext.Request.Cookies["viewMode"] ?? "light";

            return View();
        }

        [HttpPost]
        public IActionResult Preferences(string mode)
        {
            HttpContext.Response.Cookies.Append("viewMode", mode, new CookieOptions { Expires = DateTime.Now.AddYears(1) });
            return RedirectToAction("Index");
        }
    }
}
