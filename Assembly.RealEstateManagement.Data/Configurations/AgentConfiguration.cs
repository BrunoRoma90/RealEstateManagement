
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assembly.RealEstateManagement.Data.Configurations;

internal class AgentConfiguration : IEntityTypeConfiguration<Agent>
{
    public void Configure(EntityTypeBuilder<Agent> builder)
    {
        builder.OwnsOne(e => e.Name, u =>
        {
            u.Property(x => x.FirstName).HasColumnName("FirstName");
            u.Property(x => x.MiddleNames).HasColumnName("MiddleNames");
            u.Property(x => x.LastName).HasColumnName("LastName");
        });
       
        builder.HasOne(e => e.Manager).WithMany().HasForeignKey("ManagerId").
            OnDelete(DeleteBehavior.NoAction); // Sem delete em cascata

        builder.Ignore(m => m.ManagedProperty);
    }
}
