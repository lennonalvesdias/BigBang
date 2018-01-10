using BigBang.Aplicacao.Interfaces.ServicosApp;
using BigBang.Dominio.Entidades;
using BigBang.Dominio.Interfaces.Servicos;
using RecursosCompartilhados.Aplicacao.ServicosApp;

namespace BigBang.Aplicacao.ServicosApp
{
    public class PersonagemServicosApp : BaseServicosApp<Personagem>, IPersonagemServicosApp
    {
        private readonly IPersonagemServicos _servicos;

        public PersonagemServicosApp(IPersonagemServicos servicos) : base(servicos)
        {
            _servicos = servicos;
        }
    }
}