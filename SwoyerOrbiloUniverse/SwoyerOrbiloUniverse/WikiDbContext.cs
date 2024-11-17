using Microsoft.EntityFrameworkCore;
using SwoyerOrbiloUniverse.Model;

public class WikiDbContext : DbContext
{
    public DbSet<Entity> Entities { get; set; }
    public DbSet<Human> Humans { get; set; }
    public DbSet<Group> Groups { get; set; }

    public WikiDbContext(DbContextOptions<WikiDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // You can also use this to configure things like composite keys, constraints, etc.
        // modelBuilder.Entity<Entity>().HasKey(e => e.Id);
        // modelBuilder.Entity<Human>().HasKey(h => h.Id);
        // modelBuilder.Entity<Group>().HasKey(g => g.Id);
    }
}