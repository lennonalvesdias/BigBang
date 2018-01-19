using BigBang.Aplicacao.Interfaces.ServicosApp;
using BigBang.Aplicacao.ViewModels;
using MediatR;
using RecursosCompartilhados.Dominio.Entidades;

namespace BigBang.WebApi.Controllers
{
    public class PersonagemController : DefaultController<PersonagemViewModel>
    {
        private readonly IPersonagemServicosApp _servicosApp;

        public PersonagemController(
            IPersonagemServicosApp servicosApp,
            INotificationHandler<NotificacaoDeDominio> notificacoes
            ) : base(servicosApp, notificacoes)
        {
            _servicosApp = servicosApp;
        }
    }
}