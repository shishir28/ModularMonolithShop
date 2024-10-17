using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ModularMonolithShop.Shared.Kernel.Entities;

namespace ModularMonolithShop.Shared.Persistence.Interceptors
{
    public class EntityChangeInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            Intercept(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            Intercept(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public static void Intercept(DbContext? dbContext)
        {
            if (dbContext is null) return;

            foreach (var entry in dbContext.ChangeTracker.Entries<IEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.LastModifiedAt = DateTime.UtcNow;
                    entry.Entity.CreatedBy = "System";
                    entry.Entity.LastModifiedBy = "System";
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastModifiedAt = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy = "System_1";
                }
            }
        }
    }
}
