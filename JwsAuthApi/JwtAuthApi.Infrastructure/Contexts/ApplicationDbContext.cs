using JwtAuthApi.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore; 

namespace JwtAuthApi.Infrastructure.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
