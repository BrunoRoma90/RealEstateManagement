using System.Reflection.Emit;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assembly.RealEstateManagement.Data.Configurations;

internal class AgentAllContactConfiguration : IEntityTypeConfiguration<AgentAllContact>
{
    public void Configure(EntityTypeBuilder<AgentAllContact> builder)
    {
        builder.OwnsOne(e => e.Name, u =>
        {
            u.Property(x => x.FirstName).HasColumnName("FirstName");
            u.Property(x => x.MiddleNames).HasColumnName("MiddleNames");
            u.Property(x => x.LastName).HasColumnName("LastName");
        });
        builder.OwnsOne(e => e.Contact, u =>
        {
            u.Property(x => x.ContactType).HasColumnName("ContactType");
            u.Property(x => x.Value).HasColumnName("Value");

        });
    }
}
