using System.Reflection.Emit;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assembly.RealEstateManagement.Data.Configurations;

internal class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.OwnsOne(e => e.Name, u =>
        {
            u.Property(x => x.FirstName).HasColumnName("FirstName");
            u.Property(x => x.MiddleNames).HasColumnName("MiddleNames");
            u.Property(x => x.LastName).HasColumnName("LastName");
        });
        
    }
}
