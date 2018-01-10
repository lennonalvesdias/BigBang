using System;
using System.Linq;
using BigBang.Aplicacao.Interfaces.ServicosApp;
using Microsoft.AspNetCore.Mvc;

namespace BigBang.WebApi.Controllers
{
    public class PersonagemController : ControllerBase
    {
        private readonly IPersonagemServicosApp _servicosApp;

        public PersonagemController(IPersonagemServicosApp servicosApp)
        {
            _servicosApp = servicosApp;
        }

        [HttpGet]
        [Route("personagens")]
        public IActionResult Get()
        {
            var listaPersonagens = _servicosApp.Listar();

            if (listaPersonagens.Any()) {
                return Ok(new { success = true, data = listaPersonagens });
            } else {
                return BadRequest(new { success = false });
            }
        }

        [HttpGet]
        [Route("personagens/{codigo:guid}")]
        public IActionResult Get(Guid codigo)
        {
            var personagem = _servicosApp.Buscar(codigo);

            if (personagem != null) {
                return Ok(new { success = true, data = personagem });
            } else {
                return BadRequest(new { success = false });
            }
        }
    }
}