using Claro.OrderService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Claro.OrderService.Infrastructure.Persistence
{
    public class WriteDbContext : DbContext
    {
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
        }
    }
}
