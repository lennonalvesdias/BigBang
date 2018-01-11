using System;

namespace RecursosCompartilhados.Dominio.Entidades
{
    public abstract class Evento : Mensagem
    {
        public DateTime Timestamp { get; protected set; }

        protected Evento()
        {
            Timestamp = DateTime.Now;
        }
    }
}