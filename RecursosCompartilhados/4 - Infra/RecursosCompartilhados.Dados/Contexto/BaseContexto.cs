using System;
using Microsoft.EntityFrameworkCore;

namespace RecursosCompartilhados.Dados.Contexto
{
    public abstract class BaseContexto : DbContext
    {
        public abstract void ModeloCriacao(ModelBuilder modelBuilder);

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity.GetType().GetProperty("DataCriacaoRegistro") == null) continue;

                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCriacaoRegistro").CurrentValue = DateTime.Now;
                    entry.Property("DataAtualizacaoRegistro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCriacaoRegistro").IsModified = false;
                    entry.Property("DataAtualizacaoRegistro").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}