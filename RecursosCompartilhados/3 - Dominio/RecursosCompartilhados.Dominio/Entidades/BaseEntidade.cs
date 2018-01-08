using System;

namespace RecursosCompartilhados.Dominio.Entidades
{
    public abstract class BaseEntidade
    {
        public Guid Codigo { get; protected set; }

        public DateTime DataAtualizacaoRegistro { get; set; }

        public DateTime DataCriacaoRegistro { get; set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as BaseEntidade;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Codigo.Equals(compareTo.Codigo);
        }

        public static bool operator ==(BaseEntidade a, BaseEntidade b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseEntidade a, BaseEntidade b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Codigo=" + Codigo + "]";
        }
    }
}