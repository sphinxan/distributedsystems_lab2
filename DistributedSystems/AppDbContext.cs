using Microsoft.EntityFrameworkCore;

namespace DistributedSystems
{
    public class AppDbContext : DbContext
    {
        public DbSet<Link> Links { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
