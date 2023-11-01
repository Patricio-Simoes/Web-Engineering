using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FP_01_2022_2023.Models;

namespace FP_01_2022_2023.Data
{
    public class FP_01_2022_2023Context : DbContext
    {
        public FP_01_2022_2023Context (DbContextOptions<FP_01_2022_2023Context> options)
            : base(options)
        {
        }

        public DbSet<FP_01_2022_2023.Models.Aluno> Aluno { get; set; } = default!;
    }
}
