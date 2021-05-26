using crud_pessoa.api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace crud_pessoa.api.DbContextConfig.MappingEntities
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Cpf)
                .HasColumnName("Documento")
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.HasOne(x => x.Contato)
                .WithOne(x => x.Pessoa);

            builder.HasOne(x => x.Endereco)
                .WithOne(x => x.Pessoa);
        }
    }
}
