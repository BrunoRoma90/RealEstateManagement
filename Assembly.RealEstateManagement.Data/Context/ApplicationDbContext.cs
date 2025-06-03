using Assembly.RealEstateManagement.Domain.Interfaces;
using System.Linq.Expressions;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Assembly.RealEstateManagement.Data.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<Agent> Agents { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<AdministrativeUser> AdministrativeUsers { get; set; }
    public DbSet<AgentPersonalContact> AgentPersonalContacts { get; set; }
    public DbSet<ManagerPersonalContact> ManagerPersonalContacts { get; set; }
    public DbSet<AdministrativeUserPersonalContact> AdminativeUserPersonalContacts { get; set; }
    public DbSet<AgentAllContact> AgentAllContacts { get; set; }
    public DbSet<ManagerAllContact> ManagerAllContacts { get; set; }
    public DbSet<AdministrativeUserAllContact> AdministrativeUserAllContacts { get; set; }
    public DbSet<Visit> Visits { get; set; }

    public DbSet<Property> Properties { get; set; }

    public DbSet<Client> Clients { get; set; }

    public DbSet<FavoriteProperty> favoriteProperties { get; set; }







    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    public ApplicationDbContext()
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


        // Filter Soft Deleted entities on calling DbSet
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");

                var filter = Expression.Lambda(
                    Expression.Equal(
                        Expression.Property(parameter, nameof(ISoftDelete.IsDeleted)),
                        Expression.Constant(false)
                        ),
                    parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
            }
        }
    }
}
