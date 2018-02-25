using BigBang.Dominio.Entidades;
using RecursosCompartilhados.Dominio.Interfaces.Servicos;

namespace BigBang.Dominio.Interfaces.Servicos
{
    public interface IUsuarioServicos : IBaseServicos<Usuario>
    {
        Usuario Login(Usuario usuario);
    }
}