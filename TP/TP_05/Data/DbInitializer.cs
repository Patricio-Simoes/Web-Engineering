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


            var courses = new Course[]
            {
                new Course
                {
                    Name="Web Engineering",
                    Description = "Creating new sites using ASP.NET",
                    Cost = 50, Credits = 6,
                    CategoryId = categorias.Single(c=>c.Name=="Programming").Id
                },
                new Course
                {
                    Name="Strategic Leadership and Management",
                    Description = "This Master in Corporate Communication will provide required to organize a Communication Department",
                    Cost = 80, Credits = 10,
                    CategoryId = categorias.Single(c=>c.Name=="Administration").Id
                },
                new Course
                {
                    Name="Master in Corporate Communication",
                    Description = "This Master in Corporate Communication will provide required to organize a Communication Department",
                    Cost = 80, Credits = 10,
                    CategoryId = categorias.Single(c=>c.Name=="Communication").Id
                }
            };
                _context.Course.AddRange(courses);
            _context.SaveChanges();
        }
    }
}
