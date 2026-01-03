using Microsoft.EntityFrameworkCore;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Persistence.Context;

public class YummyContext : DbContext
{
    public YummyContext(DbContextOptions<YummyContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
