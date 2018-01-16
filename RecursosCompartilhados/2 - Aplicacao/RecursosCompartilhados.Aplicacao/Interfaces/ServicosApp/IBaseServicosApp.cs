using System;
using System.Collections.Generic;
using System.Linq;

namespace RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp
{
    public interface IBaseServicosApp<TViewModel> : IDisposable where TViewModel : class
    {
        void Inserir(TViewModel viewModel);
        TViewModel Buscar(Guid id);
        IList<TViewModel> Listar();
        void Atualizar(TViewModel viewModel);
        void Remover(Guid id);
        int Salvar();
    }
}