using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assembly.RealEstateManagement.Data.Configurations;

internal class ManagerConfiguration : IEntityTypeConfiguration<Manager>
{
    public void Configure(EntityTypeBuilder<Manager> builder)
    {
        builder
        .OwnsOne(e => e.Name, u =>
        {
            u.Property(x => x.FirstName).HasColumnName("FirstName");
            u.Property(x => x.MiddleNames).HasColumnName("MiddleNames");
            u.Property(x => x.LastName).HasColumnName("LastName");
        });
        builder
       .Ignore(m => m.ManagedAgents); // Ignora a propriedade na modelagem do banco de dados
    }
}
