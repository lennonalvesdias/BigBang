using BigBang.Dominio.Entidades;
using BigBang.Dominio.Interfaces.Repositorios;
using BigBang.Dominio.Interfaces.Servicos;
using RecursosCompartilhados.Dominio.Servicos;

namespace BigBang.Dominio.Servicos
{
    public class PersonagemServicos : BaseServicos<Personagem>, IPersonagemServicos
    {
        private readonly IPersonagemRepositorio _repositorio;

        public PersonagemServicos(IPersonagemRepositorio repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }
    }
}