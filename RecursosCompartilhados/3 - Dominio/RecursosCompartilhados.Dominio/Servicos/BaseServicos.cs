using System;
using System.Linq;
using RecursosCompartilhados.Dominio.Interfaces.Repositorios;
using RecursosCompartilhados.Dominio.Interfaces.Servicos;

namespace RecursosCompartilhados.Dominio.Servicos
{
    public abstract class BaseServicos<TEntidade> : IBaseServicos<TEntidade> where TEntidade : class
    {
        private readonly IBaseRepositorio<TEntidade> _repositorio;

        protected BaseServicos(IBaseRepositorio<TEntidade> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        void IBaseServicos<TEntidade>.Atualizar(TEntidade entidade)
        {
            _repositorio.Atualizar(entidade);
        }

        TEntidade IBaseServicos<TEntidade>.Buscar(Guid codigo)
        {
            return _repositorio.Buscar(codigo);
        }

        void IBaseServicos<TEntidade>.Inserir(TEntidade entidade)
        {
            _repositorio.Inserir(entidade);
        }

        IQueryable<TEntidade> IBaseServicos<TEntidade>.Listar()
        {
            return _repositorio.Listar();
        }

        void IBaseServicos<TEntidade>.Remover(Guid codigo)
        {
            _repositorio.Remover(codigo);
        }

        int IBaseServicos<TEntidade>.Salvar()
        {
            return _repositorio.Salvar();
        }
    }
}