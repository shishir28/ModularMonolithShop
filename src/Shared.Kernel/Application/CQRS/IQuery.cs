using MediatR;
using ModularMonolithShop.Shared.Kernel.Entities;

namespace ModularMonolithShop.Shared.Kernel.Application.CQRS;

public interface IQuery<out T> : IRequest<T> where T : notnull
{
    
}