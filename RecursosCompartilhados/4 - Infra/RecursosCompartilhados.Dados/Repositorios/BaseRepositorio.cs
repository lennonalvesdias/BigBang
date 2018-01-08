using System;
using System.Linq;
using RecursosCompartilhados.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RecursosCompartilhados.Dados.Repositorios
{
    public class BaseRepositorio<TEntidade, TContexto> : IRepository<TEntidade> where TEntidade : class where TContexto : DbContext, new()
    {
        protected TContexto Contexto { get; set; } = new TContexto();
        protected readonly DbSet<TEntidade> DbSet;

        public BaseRepositorio() {
            DbSet = Contexto.Set<TEntidade>();
        }

        public virtual void Inserir(TEntidade entidade)
        {
            DbSet.Add(entidade);
        }

        public virtual TEntidade Buscar(Guid codigo)
        {
            return DbSet.Find(codigo);
        }

        public virtual IQueryable<TEntidade> Listar()
        {
            return DbSet;
        }

        public virtual bool Atualizar(TEntidade entidade)
        {
            DbSet.Update(entidade);
        }

        public virtual bool Remover(Guid codigo)
        {
            DbSet.Remove(DbSet.Find(codigo));
        }

        public int Salvar()
        {
            return Context.SaveChanges();
        }

        public void Descartar()
        {
            Contexto.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}