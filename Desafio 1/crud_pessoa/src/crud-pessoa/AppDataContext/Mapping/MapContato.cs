using crud_pessoa.VOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace crud_pessoa.AppDataContext.Mapping
{
    public class MapContato : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contato");
            builder.Property<int>("Id");

            builder.Property(x => x.Email)
               .HasMaxLength(100)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(x => x.Telefon)
               .HasMaxLength(11)
               .HasColumnType("varchar(11)")
               .IsRequired();
        }
    }
}
