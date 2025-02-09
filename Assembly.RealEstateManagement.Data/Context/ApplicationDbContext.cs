using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Assembly.RealEstateManagement.Data.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<Agent> Agents { get; set; }
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
    }
}
