using System.Collections.Generic;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.Dominio.Notificacoes;

namespace RecursosCompartilhados.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly GerenciadorDeNotificacoes _notificacoes;

        protected BaseController(INotificationHandler<NotificacaoDeDominio> notificacoes) 
        {
            _notificacoes = (GerenciadorDeNotificacoes) notificacoes;            
        }

        protected IEnumerable<NotificacaoDeDominio> Notificacoes => _notificacoes.Listar();

        protected bool OperacaoValida()
        {
            return (!_notificacoes.PossuiNotificacao());
        }

        protected new IActionResult Response(object resultado = null)
        {
            if (OperacaoValida())
            {
                return Ok(
                    new { success = true, data = resultado }
                    );
            }

            return BadRequest(
                new { success = false, errors = _notificacoes.Listar().Select(n => n.Valor) }
                );
        }

        protected void NotificarErros()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var mensagemDeErro = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                ErroNotificacao(string.Empty, mensagemDeErro);
            }
        }

        protected void ErroNotificacao(string codigo, string mensagem)
        {
            _notificacoes.Adicionar(new NotificacaoDeDominio(codigo, mensagem));
        }
    }
}