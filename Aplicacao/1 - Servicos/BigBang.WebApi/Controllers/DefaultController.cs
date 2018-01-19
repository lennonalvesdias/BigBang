using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.WebApi.Controllers;

namespace BigBang.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Base")]
    public class DefaultController<TViewModel> : BaseController where TViewModel : class
    {
        private readonly IBaseServicosApp<TViewModel> _servicosApp;
        public DefaultController(IBaseServicosApp<TViewModel> servicosApp, 
            INotificationHandler<NotificacaoDeDominio> notificacoes) : base(notificacoes)
        {
            _servicosApp = servicosApp;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_servicosApp.Listar());
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            return Response(_servicosApp.Buscar(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]TViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                NotificarErros();
                return Response(vm);
            }

            _servicosApp.Inserir(vm);

            return Response(vm);
        }

        [HttpPut]
        public IActionResult Put([FromBody]TViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                NotificarErros();
                return Response(vm);
            }

            _servicosApp.Atualizar(vm);

            return Response(vm);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _servicosApp.Remover(id);

            return Response();
        }
    }
}