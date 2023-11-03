using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PAP1_2023_2024.Models;

namespace PAP1_2023_2024.Data
{
    public class PAP1_2023_2024Context : DbContext
    {
        public PAP1_2023_2024Context (DbContextOptions<PAP1_2023_2024Context> options)
            : base(options)
        {
        }

        public DbSet<PAP1_2023_2024.Models.Registo> Registo { get; set; } = default!;
    }
}
