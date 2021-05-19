using crud_pessoa.AppDataContext.Mapping;
using crud_pessoa.Models.Entity;
using crud_pessoa.VOs;
using Microsoft.EntityFrameworkCore;

namespace crud_pessoa.AppDataContext
{
    public class ApplicationDataContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>(new MapPessoa().Configure);
            modelBuilder.Entity<Contato>(new MapContato().Configure);
            modelBuilder.Entity<Endereco>(new MapEndereco().Configure);
        }
    }
}
