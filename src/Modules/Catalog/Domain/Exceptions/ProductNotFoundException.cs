

using ModularMonolithShop.Shared.Kernel.Domain.Exceptions;

namespace ModularMonolithShop.Catalog.Domain.Exceptions;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid id)
        : base("Product", id)
    {
    }
}