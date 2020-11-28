using ForexAggregator.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForexAggregator.Api.Database
{
    public class ForexAggregatorContext : IdentityDbContext<ApplicationUser>
    {
        public ForexAggregatorContext() { }
        public ForexAggregatorContext(DbContextOptions<ForexAggregatorContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Exchange>().Property(e => e.ExchangeRate).HasPrecision(18, 5);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<Provider> Provider { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Exchange> Exchange { get; set; }
    }
}
