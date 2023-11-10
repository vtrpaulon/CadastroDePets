using Microsoft.EntityFrameworkCore;

namespace CadastroDePets.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Pets> Pets { get; set; }
    }
}
