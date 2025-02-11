using System.Reflection.Emit;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assembly.RealEstateManagement.Data.Configurations;

internal class AgentPersonalContactConfiguration : IEntityTypeConfiguration<AgentPersonalContact>
{
    public void Configure(EntityTypeBuilder<AgentPersonalContact> builder)
    {
        builder.OwnsOne(e => e.Contact, u =>
        {
            u.Property(x => x.ContactType).HasColumnName("ContactType");
            u.Property(x => x.Value).HasColumnName("Value");

        });
    }
}
