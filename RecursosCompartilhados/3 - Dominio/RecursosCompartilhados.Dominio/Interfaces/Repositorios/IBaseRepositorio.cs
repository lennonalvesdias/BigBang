using System;
using System.Linq;

namespace RecursosCompartilhados.Dominio.Interfaces
{
    public interface IBaseRepositorio<TEntidade> : IDisposable where TEntidade : class
    {
        void Inserir(TEntidade entidade);
        TEntidade Buscar(Guid codigo);
        IQueryable<TEntidade> Listar();
        void Atualizar(TEntidade entidade);
        void Remover(Guid codigo);
        int Salvar();
    }
}