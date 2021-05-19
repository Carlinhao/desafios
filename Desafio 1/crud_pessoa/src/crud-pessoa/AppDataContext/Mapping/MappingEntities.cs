using crud_pessoa.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace crud_pessoa.AppDataContext.Mapping
{
    public class MappingEntities : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Idade)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(p => p.Cpf)
                .HasMaxLength(11)
                .IsRequired();

            builder.HasOne(x => x.Endereco);

            builder.HasOne(x => x.Contato);

        }
    }
}
