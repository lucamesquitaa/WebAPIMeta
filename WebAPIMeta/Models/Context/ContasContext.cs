using Microsoft.EntityFrameworkCore;

namespace WebAPIMeta.Models.Context
{
    public class ContasContext : DbContext
    {
        public ContasContext(DbContextOptions<ContasContext> options) : base(options)
        {

        }

        public DbSet<Contas> Contas { get; set; }
    }
}
