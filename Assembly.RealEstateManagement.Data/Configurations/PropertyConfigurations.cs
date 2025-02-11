using System.Reflection.Emit;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assembly.RealEstateManagement.Data.Configurations;

internal class PropertyConfigurations : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.Property(p => p.Price).HasPrecision(18, 2);

        builder.Property(p => p.PriceBySquareMeter).HasPrecision(18, 4);

        builder.Property(p => p.SizeBySquareMeters).HasPrecision(10, 2);
        builder.
            HasOne(e => e.Agent).WithMany().HasForeignKey("AgentId").
            OnDelete(DeleteBehavior.NoAction);
    }
}
