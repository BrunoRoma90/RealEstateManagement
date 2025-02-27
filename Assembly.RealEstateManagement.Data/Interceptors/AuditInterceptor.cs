using Assembly.RealEstateManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Assembly.RealEstateManagement.Data.Interceptors;

internal class AuditInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var context = eventData.Context;

        var currentTime = DateTime.UtcNow;


        // Loop through all entities in the context
        foreach (var entry in context.ChangeTracker.Entries())
        {
            // Check if the entity is IAuditableEntity
            if (entry.Entity is IAuditableEntity<int> auditableEntity)
            {
                if (entry.State == EntityState.Added)
                {
                    // Set Created and Updated for added entities
                    auditableEntity.Create(currentTime);
                }
                else if (entry.State == EntityState.Modified)
                {
                    // Only update Updated for modified entities
                    auditableEntity.Update(currentTime);
                }
            }
        }

        return base.SavingChanges( eventData, result);
    }


}
