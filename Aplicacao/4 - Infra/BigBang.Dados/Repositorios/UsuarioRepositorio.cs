using BigBang.Dados.Contexto;
using BigBang.Dominio.Entidades;
using BigBang.Dominio.Interfaces.Repositorios;
using RecursosCompartilhados.Dados.Repositorios;
using System.Linq;

namespace BigBang.Dados.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario, BigBangContexto>, IUsuarioRepositorio
    {
        Usuario IUsuarioRepositorio.Login(Usuario usuario)
        {
            return Contexto.Set<Usuario>().FirstOrDefault(u => u.Apelido == usuario.Apelido && u.Senha == usuario.Senha);
        }
    }
}