using System;
using System.Collections.Generic;
using RecursosCompartilhados.Dominio.Entidades;

namespace BigBang.Dominio.Entidades
{
    public class Personagem : BaseEntidade
    {
        public Personagem(string nome)
        {
            Nome = nome;
        }

        protected Personagem() { }
        
        public string Nome { get; private set; }
    }
}