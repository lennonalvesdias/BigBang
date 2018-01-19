using System;
using FluentValidation;
using FluentValidation.Results;

namespace RecursosCompartilhados.Dominio.Entidades
{
    public abstract class BaseEntidade<TEntidade> : AbstractValidator<TEntidade>
    {
        public Guid Id { get; protected set; }

        public DateTime DataAtualizacaoRegistro { get; set; }

        public DateTime DataCriacaoRegistro { get; set; }

        protected ValidationResult Validacao { get; set; }

        public abstract bool EhValido();

        public override bool Equals(object obj)
        {
            var compareTo = obj as BaseEntidade<TEntidade>;

            if (ReferenceEquals(this, compareTo)) return true;

            return !ReferenceEquals(null, compareTo) && Id.Equals(compareTo.Id);
        }

        public static bool operator ==(BaseEntidade<TEntidade> a, BaseEntidade<TEntidade> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseEntidade<TEntidade> a, BaseEntidade<TEntidade> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }
}