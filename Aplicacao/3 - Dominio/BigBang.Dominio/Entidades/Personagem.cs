using System;
using System.Collections.Generic;
using RecursosCompartilhados.Dominio.Entidades;

namespace BigBang.Dominio.Entidades
{
    public class Personagem : BaseEntidade
    {
        protected Personagem() { }
        public Personagem(string nome)
        {
            Nome = nome;

            EValidoAoCriar();
        }
        public string Nome { get; private set; }

        private void EValidoAoCriar()
        {
            // Domain Notifications
        }

        private void EValidoAoAtualizar()
        {
            // Domain Notifications
        }

        public override string ToString() => $"Id: {Id}, Nome: {Nome}";
    }
}