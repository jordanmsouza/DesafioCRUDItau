using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DesafioCRUDItau.Models
{
    public class Context : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Chamado> Chamados { get; set; }

        public DbSet<Gravidade> Gravidades { get; set; }

        public DbSet<TipoSolicitacao> TipoSolicitacaos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString:@"Server=(localdb)\mssqllocaldb;Database=DesafioCRUDItau;Integrated Security = True");
        }
    }
}
