using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP_08.Models;

namespace TP_08.Data
{
    public class TP_08Context : DbContext
    {
        public TP_08Context (DbContextOptions<TP_08Context> options)
            : base(options)
        {
        }

        public DbSet<TP_08.Models.User> User { get; set; } = default!;
    }
}
