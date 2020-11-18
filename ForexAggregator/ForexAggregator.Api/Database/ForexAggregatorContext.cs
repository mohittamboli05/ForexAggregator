using ForexAggregator.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ForexAggregator.Api.Database
{
    public class ForexAggregatorContext : DbContext
    {
        public ForexAggregatorContext() { }
        public ForexAggregatorContext(DbContextOptions<ForexAggregatorContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<ApplicationRole> ApplicationRole { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Exchange> Exchange { get; set; }
    }
}
