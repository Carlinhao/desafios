using crud_pessoa.api.Entities;
using Microsoft.EntityFrameworkCore;


namespace crud_pessoa.api.DbContextConfig
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }
    }
}
