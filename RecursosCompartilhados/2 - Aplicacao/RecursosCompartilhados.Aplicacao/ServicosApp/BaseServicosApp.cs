using System;
using System.Linq;
using RecursosCompartilhados.Dominio.Interfaces.Servicos;
using RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp;
using System.Collections.Generic;

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

        TEntidade IBaseServicosApp<TEntidade>.Buscar(Guid id)
        {
            return _servicos.Buscar(id);
        }

        void IDisposable.Dispose()
        {
            _servicos.Dispose();
        }

        void IBaseServicosApp<TEntidade>.Inserir(TEntidade entidade)
        {
            _servicos.Inserir(entidade);
        }

        IList<TEntidade> IBaseServicosApp<TEntidade>.Listar()
        {
            return _servicos.Listar();
        }

        void IBaseServicosApp<TEntidade>.Remover(Guid id)
        {
            _servicos.Remover(id);
        }

        int IBaseServicosApp<TEntidade>.Salvar()
        {
            return _servicos.Salvar();
        }
    }
}