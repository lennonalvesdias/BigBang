using System;
using System.Linq;
using RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp;

namespace RecursosCompartilhados.Aplicacao.ServicosApp
{
    public class BaseServicosApp<TEntidade> : IBaseServicosApp<TEntidade> where TEntidade : class
    {
        private readonly IBaseServicos<TEntidade> _servicos;

        protected BaseServicosApp(IBaseServicos<TEntidade> servicos)
        {
            _servicos = servicos;
        }

        void IBaseServicosApp<TEntidade>.Atualizar(TEntidade entidade)
        {
            _servicos.Atualizar(entidade);
        }

        TEntidade IBaseServicosApp<TEntidade>.Buscar(Guid codigo)
        {
            return _servicos.Buscar(codigo);
        }

        void IDisposable.Dispose()
        {
            _servicos.Dispose();
        }

        void IBaseServicosApp<TEntidade>.Inserir(TEntidade entidade)
        {
            _servicos.Inserir(entidade);
        }

        IQueryable<TEntidade> IBaseServicosApp<TEntidade>.Listar()
        {
            return _servicos.Listar();
        }

        void IBaseServicosApp<TEntidade>.Remover(Guid codigo)
        {
            _servicos.Remover(codigo);
        }

        int IBaseServicosApp<TEntidade>.Salvar()
        {
            return _servicos.Salvar();
        }
    }
}