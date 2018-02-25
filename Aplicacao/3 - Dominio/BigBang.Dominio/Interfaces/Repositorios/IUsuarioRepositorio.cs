using BigBang.Dominio.Entidades;
using RecursosCompartilhados.Dominio.Interfaces.Repositorios;

namespace BigBang.Dominio.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        Usuario Login(Usuario usuario);
    }
}