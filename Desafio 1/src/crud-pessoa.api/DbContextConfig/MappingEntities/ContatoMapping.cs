using crud_pessoa.api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace crud_pessoa.api.DbContextConfig.MappingEntities
{
    public class ContatoMapping : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contato");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(x => x.Telefone)
                .HasColumnName("Telefone")
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(x => x.PessoaId)
                .HasColumnName("PessoaId");
        }
    }
}
