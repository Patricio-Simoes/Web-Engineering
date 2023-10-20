using TP_04.Models;

namespace TP_04.Data
{
    public class DbInitializer
    {
        private TP_04Context _context;
        public DbInitializer(TP_04Context context)
        {
            _context = context;
        }
        public void Run()
        {
            _context.Database.EnsureCreated();
            if(_context.Category.Any())
            {
                return;
            }
            var categorias = new Category[]
            {
                new Category {Name="Programming", Description="Algoritms and programming area courses"},
                new Category {Name="Administration", Description="Public administration and business management courses"},
                new Category {Name="Communication", Description="Business and institutional communication course"}
            };
            foreach(var c in categorias)
            {
                _context.Category.Add(c);
            }
            _context.SaveChanges();
        }
    }
}
