using Microsoft.EntityFrameworkCore;
using Crowdfunding_app.Models;
using System.Collections.Generic;

namespace Crowdfunding_app
{
    

public class CrowdfundingDbContext : DbContext
{
    public CrowdfundingDbContext(DbContextOptions<CrowdfundingDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    // Add other entities here
}
}