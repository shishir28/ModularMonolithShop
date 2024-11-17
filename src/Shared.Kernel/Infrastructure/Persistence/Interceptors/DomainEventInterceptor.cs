using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ModularMonolithShop.Shared.Kernel;

namespace ModularMonolithShop.Shared.Persistence.Interceptors
{
    public class DomainEventInterceptor(IMediator _mediator) : SaveChangesInterceptor
    {
        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            Intercept(eventData.Context).GetAwaiter().GetResult();
            return base.SavedChanges(eventData, result);
        }
        public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            await Intercept(eventData.Context);
            return await base.SavedChangesAsync(eventData, result, cancellationToken);
        }

        public async Task Intercept(DbContext? dbContext)
        {
            if (dbContext is null) return;

            foreach (var aggregate in dbContext.ChangeTracker.Entries<IAggregate>())
            {
                foreach (var domainEvent in aggregate.Entity.DomainEvents)
                    await _mediator.Publish(domainEvent);

                aggregate.Entity.ClearDomainEvents();
            }
        }
    }
}
