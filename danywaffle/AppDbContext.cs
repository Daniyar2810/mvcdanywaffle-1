
using danywaffle.Domain;
using Microsoft.EntityFrameworkCore;

namespace danywaffle;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public virtual DbSet<Category> Categories {  get; set; }
    public virtual DbSet<Product> Products{ get; set; }
}
