using Assembly.RealEstateManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualBasic;

namespace Assembly.RealEstateManagement.Data.Interceptors;

internal class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result) 
    {
        var context = eventData.Context;

        foreach (var entry in context.ChangeTracker.Entries<ISoftDelete>())
        {
            if (entry.State == EntityState.Deleted) 
            {
                entry.State = EntityState.Modified;
                entry.Entity.Delete();
            }
        }

        return base.SavingChanges(eventData, result);
    }

}
