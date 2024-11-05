using MediatR;

namespace ModularMonolithShop.Shared.Kernel.Application.CQRS;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand,TResponse>
where TCommand : ICommand<TResponse>
where TResponse: notnull
{
    
}

public interface ICommandHndler<in TCommand> : IRequestHandler<TCommand, Unit>
    where TCommand : ICommand<Unit>
{
    
}