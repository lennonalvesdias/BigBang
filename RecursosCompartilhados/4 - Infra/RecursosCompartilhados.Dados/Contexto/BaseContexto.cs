using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RecursosCompartilhados.Dados.Contexto
{
    public abstract class BaseContexto : DbContext
    {
        // public BaseContexto(DbContextOptions options) : base(options)
        // {

        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // public override int SaveChanges()
        // {
        //     foreach (var entry in ChangeTracker.Entries())
        //     {
        //         if (entry.Entity.GetType().GetProperty("DataCriacaoRegistro") == null) continue;

        //         if (entry.State == EntityState.Added)
        //         {
        //             entry.Property("DataCriacaoRegistro").CurrentValue = DateTime.Now;
        //             entry.Property("DataAtualizacaoRegistro").CurrentValue = DateTime.Now;
        //         }

        //         if (entry.State == EntityState.Modified)
        //         {
        //             entry.Property("DataCriacaoRegistro").IsModified = false;
        //             entry.Property("DataAtualizacaoRegistro").CurrentValue = DateTime.Now;
        //         }
        //     }

        //     return base.SaveChanges();
        // }

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