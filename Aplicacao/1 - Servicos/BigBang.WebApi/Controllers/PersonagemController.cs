using System;
using System.Linq;
using BigBang.Aplicacao.Interfaces.ServicosApp;
using BigBang.Aplicacao.ViewModels;
using BigBang.Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecursosCompartilhados.Aplicacao.ViewModel;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.WebApi.Controllers;

namespace BigBang.WebApi.Controllers
{
    public class PersonagemController : BaseController
    {
        private readonly IPersonagemServicosApp _servicosApp;

        public PersonagemController(
            IPersonagemServicosApp servicosApp,
            INotificationHandler<NotificacaoDeDominio> notificacoes
            ) : base(notificacoes)
        {
            _servicosApp = servicosApp;
        }

        [HttpGet]
        [Route("personagens")]
        public IActionResult Get()
        {
            return Response(_servicosApp.Listar());
        }

        [HttpGet]
        [Route("personagens/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            return Response(_servicosApp.Buscar(id));
        }

        [HttpPost]
        [Route("personagens")]
        public IActionResult Post([FromBody]PersonagemViewModel vm)
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
        [Route("personagens")]
        public IActionResult Put([FromBody]PersonagemViewModel vm)
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
        [Route("personagens/{id}")]
        public IActionResult Delete(Guid id)
        {
            _servicosApp.Remover(id);
            
            return Response();
        }
    }
}