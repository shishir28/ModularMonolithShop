using MediatR;

namespace ModularMonolithShop.Shared.Kernel.Application.CQRS;

public interface ICommand:ICommand<Unit>
{
    
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
    
}