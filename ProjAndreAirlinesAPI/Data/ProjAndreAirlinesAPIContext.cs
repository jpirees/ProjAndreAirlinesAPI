using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace ProjAndreAirlinesAPI.Data
{
    public class ProjAndreAirlinesAPIContext : DbContext
    {
        public ProjAndreAirlinesAPIContext (DbContextOptions<ProjAndreAirlinesAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Model.Endereco> Endereco { get; set; }

        public DbSet<Model.Passageiro> Passageiro { get; set; }

        public DbSet<Model.Aeroporto> Aeroporto { get; set; }

        public DbSet<Model.Aeronave> Aeronave { get; set; }

        public DbSet<Model.Voo> Voo { get; set; }
    }
}
