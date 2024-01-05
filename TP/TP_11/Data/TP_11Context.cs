using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP_11.Models;

namespace TP_11.Data
{
    public class TP_11Context : DbContext
    {
        public TP_11Context (DbContextOptions<TP_11Context> options)
            : base(options)
        {
        }

        public DbSet<TP_11.Models.Person> Person { get; set; } = default!;
    }
}
