using crud_pessoa.api.DbContextConfig.MappingEntities;
using crud_pessoa.api.Entities;
using Microsoft.EntityFrameworkCore;

namespace crud_pessoa.api.DbContextConfig
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=crud_pessoa;User ID=SA;Password=DockerSql2017!");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>(new PessoaMapping().Configure);
            modelBuilder.Entity<Contato>(new ContatoMapping().Configure);
            modelBuilder.Entity<Endereco>(new EnderecoMapping().Configure);
        }
    }
}
