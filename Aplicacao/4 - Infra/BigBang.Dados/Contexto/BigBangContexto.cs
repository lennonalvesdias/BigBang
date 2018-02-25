using System.IO;
using BigBang.Dados.EntidadesConfig;
using BigBang.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecursosCompartilhados.Dados.Contexto;

namespace BigBang.Dados.Contexto
{
    public class BigBangContexto : BaseContexto
    {
        public DbSet<Personagem> Personagens { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonagemConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}