using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FP_01_2021_2022.Models;

namespace FP_01_2021_2022.Data
{
    public class FP_01_2021_2022Context : DbContext
    {
        public FP_01_2021_2022Context (DbContextOptions<FP_01_2021_2022Context> options)
            : base(options)
        {
        }

        public DbSet<FP_01_2021_2022.Models.Contacto> Contacto { get; set; } = default!;
    }
}
