using crud_pessoa.Models.Entity;
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
    }
}
