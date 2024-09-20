using Microsoft.EntityFrameworkCore;
using SharedModels;

public class MyAppDbContext : DbContext
{
    public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options) { }

    // Define your DB sets here
    public DbSet<User> Users { get; set; }
}