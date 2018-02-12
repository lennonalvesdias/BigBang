using BigBang.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigBang.Dados.EntidadesConfig
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Apelido)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(c => c.Senha)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();
        }
    }
}