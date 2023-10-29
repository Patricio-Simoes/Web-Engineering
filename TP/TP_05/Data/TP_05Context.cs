using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP_05.Models;

namespace TP_05.Data
{
    public class TP_05Context : DbContext
    {
        public TP_05Context (DbContextOptions<TP_05Context> options)
            : base(options)
        {
        }

        public DbSet<TP_05.Models.Category> Category { get; set; } = default!;
        public DbSet<TP_05.Models.Course>? Course { get; set; }
    }
}
