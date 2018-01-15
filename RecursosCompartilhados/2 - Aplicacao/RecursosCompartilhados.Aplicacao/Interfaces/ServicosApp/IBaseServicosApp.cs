using System;
using System.Linq;

namespace RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp
{
    public interface IBaseServicosApp<TViewModel> : IDisposable where TViewModel : class
    {
        void Inserir(TViewModel viewModel);
        TViewModel Buscar(Guid id);
        IQueryable<TViewModel> Listar();
        void Atualizar(TViewModel viewModel);
        void Remover(Guid id);
        int Salvar();
    }
}