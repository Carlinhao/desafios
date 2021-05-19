using crud_pessoa.VOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace crud_pessoa.AppDataContext.Mapping
{
    public class MapEndereco : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");
            
            builder.Property<int>("Id")
                .IsRequired();

            builder.HasKey("Id");

            builder.Property(x => x.Bairro)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Cidade)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Estado)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Numero)
                .HasMaxLength(5)
                .HasColumnType("varchar(5)")
                .IsRequired();

            builder.Property(x => x.Rua)
               .HasMaxLength(100)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(x => x.Cep)
               .HasMaxLength(8)
               .HasColumnType("varchar(8)")
               .IsRequired();

        }
    }
}
