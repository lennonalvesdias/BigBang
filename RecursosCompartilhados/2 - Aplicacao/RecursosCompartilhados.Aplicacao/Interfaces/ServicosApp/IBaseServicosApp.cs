using System;
using System.Linq;

namespace RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp
{
    public interface IBaseServicosApp<TEntidade> : IDisposable where TEntidade : class
    {
        void Inserir(TEntidade entidade);
        TEntidade Buscar(Guid codigo);
        IQueryable<TEntidade> Listar();
        void Atualizar(TEntidade entidade);
        void Remover(Guid codigo);
        int Salvar();
    }
}