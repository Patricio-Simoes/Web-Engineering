using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FP_02_2021_2022.Models;

    public class EW_2021_PAP1_DB_alXXXXX : DbContext
    {
        public EW_2021_PAP1_DB_alXXXXX (DbContextOptions<EW_2021_PAP1_DB_alXXXXX> options)
            : base(options)
        {
        }

        public DbSet<FP_02_2021_2022.Models.Livro> Livro { get; set; } = default!;
    }
