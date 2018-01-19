using BigBang.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigBang.Dados.EntidadesConfig
{
    public class PersonagemConfig : IEntityTypeConfiguration<Personagem>
    {
        public void Configure(EntityTypeBuilder<Personagem> builder)
        {
            builder.ToTable("Personagens");
            
            builder.HasIndex(x => x.Nome)
                .IsUnique();

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(120)")
                .HasMaxLength(120)
                .IsRequired();

            builder.Property(c => c.Idade)
                .HasColumnType("integer")
                .IsRequired();
        }
    }
}