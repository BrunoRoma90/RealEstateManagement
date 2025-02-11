using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assembly.RealEstateManagement.Data.Configurations;

internal class AdministrativeUserPersonalContactConfiguration : IEntityTypeConfiguration<AdministrativeUserPersonalContact>
{
    public void Configure(EntityTypeBuilder<AdministrativeUserPersonalContact> builder)
    {
        builder.OwnsOne(e => e.Contact, u =>
        {
            u.Property(x => x.ContactType).HasColumnName("ContactType");
            u.Property(x => x.Value).HasColumnName("Value");

        });
    }
}
