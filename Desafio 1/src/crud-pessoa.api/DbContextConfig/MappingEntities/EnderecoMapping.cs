using crud_pessoa.api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace crud_pessoa.api.DbContextConfig.MappingEntities
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Pais)
                .HasColumnName("Pais")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(x => x.Estado)
                .HasColumnName("Estado")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Cidade)
                .HasColumnName("Cidade")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Bairro)
                .HasColumnName("Bairro")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Rua)
                .HasColumnName("Rua")
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(x => x.Numero)
                .HasColumnName("Numero")
                .HasColumnType("char(6)")
                .IsRequired();

            builder.Property(x => x.PessoaId)
                .HasColumnName("PessoaId");
        }
    }
}
