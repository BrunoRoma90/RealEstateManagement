using System.Reflection.Emit;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assembly.RealEstateManagement.Data.Configurations;

internal class VisitConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder
         .HasOne(v => v.Client)
         .WithMany() // Se não houver navegação inversa
         .HasForeignKey("ClientId")
         .OnDelete(DeleteBehavior.NoAction); // Impede a exclusão em cascata

        builder
            .HasOne(v => v.Property)
            .WithMany()
            .HasForeignKey("PropertyId")
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(v => v.Agent)
            .WithMany()
            .HasForeignKey("AgentId")
            .OnDelete(DeleteBehavior.NoAction);
    }
}
