using System;

namespace RecursosCompartilhados.Dominio.Entidades
{
    public class NotificacaoDeDominio : Evento
    {
        public Guid NotificacaoId { get; private set; }
        public string Chave { get; private set; }
        public string Valor { get; private set; }
        public int Versao { get; private set; }

        public NotificacaoDeDominio(string chave, string valor)
        {
            NotificacaoId = Guid.NewGuid();
            Versao = 1;
            Chave = chave;
            Valor = valor;
        }
    }
}