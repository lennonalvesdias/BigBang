using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecursosCompartilhados.Dominio.Entidades;

namespace RecursosCompartilhados.Dominio.Notificacoes
{
    public class GerenciadorDeNotificacoes : INotificationHandler<NotificacaoDeDominio>
    {
        private List<NotificacaoDeDominio> _notificacoes;

        public GerenciadorDeNotificacoes()
        {
            _notificacoes = new List<NotificacaoDeDominio>();
        }

        public virtual List<NotificacaoDeDominio> Listar()
        {
            return _notificacoes;
        }

        public virtual bool PossuiNotificacao()
        {
            return Listar().Any();
        }

        public void Dispose()
        {
            _notificacoes = new List<NotificacaoDeDominio>();
        }

        public void Adicionar(NotificacaoDeDominio notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        Task INotificationHandler<NotificacaoDeDominio>.Handle(NotificacaoDeDominio notificacao, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}