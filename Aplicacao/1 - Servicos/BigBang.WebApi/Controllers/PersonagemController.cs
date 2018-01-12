using System;
using System.Linq;
using BigBang.Aplicacao.Interfaces.ServicosApp;
using BigBang.Aplicacao.ViewModels;
using BigBang.Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Post([FromBody]Personagem entidade)
        {
            if (!ModelState.IsValid)
            {
                NotificarErros();
                return Response(entidade);
            }

            _servicosApp.Inserir(entidade);

            return Response(entidade);
        }

        [HttpPut]
        [Route("personagens")]
        public IActionResult Put([FromBody]Personagem entidade)
        {
            if (!ModelState.IsValid)
            {
                NotificarErros();
                return Response(entidade);
            }

            _servicosApp.Atualizar(entidade);

            return Response(entidade);
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