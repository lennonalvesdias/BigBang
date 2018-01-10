using BigBang.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigBang.Dados.EntidadesConfig
{
    public class PersonagemConfig : IEntityTypeConfiguration<Personagem>
    {
        public void Configure(EntityTypeBuilder<Personagem> builder)
        {
            builder.ToTable("Personagem");
            builder.HasIndex(x => new {x.Nome, x.Principal});
            builder.Property(x => x.Codigo).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.Nome).HasMaxLength(80).IsRequired();
            builder.Property(x => x.Principal).IsRequired();
        }
    }
}