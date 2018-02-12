using BigBang.Dados.Contexto;
using BigBang.Dominio.Entidades;
using BigBang.Dominio.Interfaces.Repositorios;
using RecursosCompartilhados.Dados.Repositorios;

namespace BigBang.Dados.Repositorios
{
    public class PersonagemRepositorio : BaseRepositorio<Personagem, BigBangContexto>, IPersonagemRepositorio
    {
    }
}