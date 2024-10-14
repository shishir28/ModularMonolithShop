using ModularMonolithShop.Catalog.Domain.Entities;
using ModularMonolithShop.Shared.Kernel;

namespace ModularMonolithShop.Catalog.Domain.Events;

public class ProductCreatedEvent : IDomainEvent
{
    private readonly Product _product;

    public ProductCreatedEvent(Product product)
    {
        _product = product;
    }
}