using TP_05.Models;

namespace TP_05.Data
{
    public class DbInitializer
    {
        private TP_05Context _context;
        public DbInitializer(TP_05Context context)
        {
            _context = context;
        }
        public void Run()
        {
            _context.Database.EnsureCreated();
            if (_context.Category.Any())
            {
                return;
            }
            var categorias = new Category[]
            {
                new Category {Name = "Programming", Description="Algoritms and programming area courses", Date=DateTime.Now},
                new Category {Name = "Administration", Description="Public administration and business management courses", Date=DateTime.Now},
                new Category {Name="Communication", Description="Business and institutional communication course", Date = DateTime.Now}
            };
            foreach(var c in categorias)
            {
                _context.Category.Add(c);
            }
            _context.SaveChanges();
        }
    }
}
