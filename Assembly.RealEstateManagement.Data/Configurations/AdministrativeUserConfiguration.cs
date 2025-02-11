using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assembly.RealEstateManagement.Data.Configurations;

internal class AdministrativeUserConfiguration : IEntityTypeConfiguration<AdministrativeUser>
{
    public void Configure(EntityTypeBuilder<AdministrativeUser> builder)
    {
        builder.OwnsOne(e => e.Name, u =>
        {
            u.Property(x => x.FirstName).HasColumnName("FirstName");
            u.Property(x => x.MiddleNames).HasColumnName("MiddleNames");
            u.Property(x => x.LastName).HasColumnName("LastName");
        });
    }
}
