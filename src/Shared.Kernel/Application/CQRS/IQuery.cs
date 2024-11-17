using MediatR;

namespace ModularMonolithShop.Shared.Kernel.Application.CQRS;

public interface IQuery<out T> : IRequest<T> where T : notnull
{
    
}