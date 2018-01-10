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

        public override void ModeloCriacao(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Personagem>(new PersonagemConfig());
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