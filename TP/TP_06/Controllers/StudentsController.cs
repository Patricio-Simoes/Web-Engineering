using Class06.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Class06.Controllers
{
    public class StudentsController : Controller
    {
        private readonly Class06Context _context;
        public StudentsController(Class06Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var allStudents = _context.Students.Include(c=>c.Class);
            return View(allStudents);
        }
        public async Task<IActionResult> Index2(string letter)
        {
            if (!string.IsNullOrEmpty(letter))
            {
                return View(await _context.Students.Where(x => x.Name.StartsWith(letter)).Include(c => c.Class).ToListAsync());
            }
            return View(await _context.Students.Include(c => c.Class).ToListAsync());
        }
    }
}
