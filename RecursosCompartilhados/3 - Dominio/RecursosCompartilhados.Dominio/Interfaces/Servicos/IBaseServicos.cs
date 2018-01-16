using System;
using System.Collections.Generic;
using System.Linq;

namespace RecursosCompartilhados.Dominio.Interfaces.Servicos
{
    public interface IBaseServicos<TEntidade> : IDisposable where TEntidade : class
    {
        void Inserir(TEntidade entidade);
        TEntidade Buscar(Guid id);
        IList<TEntidade> Listar();
        void Atualizar(TEntidade entidade);
        void Remover(Guid id);
        int Salvar();
    }
}