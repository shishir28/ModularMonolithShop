using MediatR;

namespace ModularMonolithShop.Shared.Kernel.Application.CQRS;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse> 
    where TQuery : IQuery<TResponse>
    where TResponse : notnull
{
    
}