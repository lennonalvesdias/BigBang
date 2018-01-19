using FluentValidation;
using RecursosCompartilhados.Dominio.Entidades;

namespace BigBang.Dominio.Entidades
{
    public class Personagem : BaseEntidade<Personagem>
    {
        // Construtor para EF
        protected Personagem() { }
        public Personagem(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }
        public string Nome { get; private set; }
        public int Idade { get; private set; }

        public override bool EhValido()
        {
            Validar();
            return Validacao.Errors.Count > 0;
        }

        private void Validar()
        {
            RuleFor(r => r.Nome)
                .NotEmpty().WithMessage("É preciso fornecener um nome")
                .Length(3, 120).WithMessage("É preciso fornecer um nome entre 3 e 120 caracteres");

            RuleFor(r => Idade)
                .InclusiveBetween(1, 100).WithMessage("É preciso fornecer uma idade entre 1 e 100");
        }


        public override string ToString() => $"Id: {Id}, Nome: {Nome}";
    }
}