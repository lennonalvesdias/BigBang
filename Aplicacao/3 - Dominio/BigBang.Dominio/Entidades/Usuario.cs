using RecursosCompartilhados.Dominio.Entidades;

namespace BigBang.Dominio.Entidades
{
    public class Usuario : BaseEntidade
    {
        public Usuario(string nome, string apelido, string senha)
        {
            Nome = nome;
            Apelido = apelido;
            Senha = senha;
        }

        protected Usuario() { }

        public string Nome { get; private set; }
        public string Apelido { get; private set; }
        public string Senha { get; private set; }
    }
}