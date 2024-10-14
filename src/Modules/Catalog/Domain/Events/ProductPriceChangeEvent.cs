using ModularMonolithShop.Catalog.Domain.Entities;
using ModularMonolithShop.Shared.Kernel;

namespace ModularMonolithShop.Catalog.Domain.Events;

public class ProductPriceChangeEvent : IDomainEvent
{
    private readonly Product _product;

    public ProductPriceChangeEvent(Product product)
    {
        _product = product;
    }
}