using System;
using MediatR;

namespace RecursosCompartilhados.Dominio.Entidades
{
    public abstract class Mensagem : INotification
    {
        public string TipoMensagem { get; protected set; }
        public Guid MensagemId { get; protected set; }

        protected Mensagem()
        {
            TipoMensagem = GetType().Name;
        }
    }
}