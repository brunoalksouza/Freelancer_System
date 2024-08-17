using DataEF.Configurations;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataEF;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Proposal> Proposals { get; set; }
    public DbSet<Review> Reviews{ get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceType> ServiceTypes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfig());
    }
}