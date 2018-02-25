using BigBang.Dominio.Entidades;
using BigBang.Dominio.Interfaces.Repositorios;
using BigBang.Dominio.Interfaces.Servicos;
using RecursosCompartilhados.Dominio.Servicos;

namespace BigBang.Dominio.Servicos
{
    public class UsuarioServicos : BaseServicos<Usuario>, IUsuarioServicos
    {
        private readonly IUsuarioRepositorio _repositorio;

        public UsuarioServicos(IUsuarioRepositorio repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        Usuario IUsuarioServicos.Login(Usuario usuario)
        {
            return _repositorio.Login(usuario);
        }
    }
}