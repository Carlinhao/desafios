using Microsoft.EntityFrameworkCore;

namespace crud_pessoa.AppDataContext
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) 
            : base(options)
        {
        }
    }
}
