using System.Collections.Generic;
using RecursosCompartilhados.Dominio.Entidades;

namespace BigBang.Dominio.Entidades
{
    public class Personagem : BaseEntidade
    {
        public string Nome { get; set; }
        public string AtuadoPor { get; set; }
        public bool Principal { get; set; }
        public ICollection<int> Temporadas { get; set; }
    }
}