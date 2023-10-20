using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP_04.Models;

namespace TP_04.Data
{
    public class TP_04Context : DbContext
    {
        public TP_04Context (DbContextOptions<TP_04Context> options)
            : base(options)
        {
        }

        public DbSet<TP_04.Models.Category> Category { get; set; } = default!;
    }
}
