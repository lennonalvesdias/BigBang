using System;
using BigBang.Aplicacao.Interfaces.ServicosApp;
using Microsoft.AspNetCore.Mvc;

namespace BigBang.WebApi.Controllers
{
    public class PersonagemController : ControllerBase
    {
        private readonly IPersonagemServicosApp _servicosApp;

        public PersonagemController(IPersonagemServicosApp servicosApp) {
            _servicosApp = servicosApp;
        }

        [HttpGet]
        [Route("personagens")]
        public IActionResult Get()
        {
            return Response(_servicosApp.Listar());
        }

        [HttpGet]
        [Route("personagens/{codigo:guid}")]
        public IActionResult Get(Guid codigo)
        {
            // var customerViewModel = _customerAppService.GetById(id);

            return Response(_servicosApp.Buscar(codigo));
        }   
    }
}