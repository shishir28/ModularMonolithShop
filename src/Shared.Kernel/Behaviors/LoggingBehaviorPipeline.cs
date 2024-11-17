using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;
using ModularMonolithShop.Shared.Kernel.Application.CQRS;

namespace Shared.Kernel.Behaviors;

public class LoggingBehaviorPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand<TResponse>
{
    private readonly ILogger<LoggingBehaviorPipeline<TRequest, TResponse>> _logger;

    public LoggingBehaviorPipeline(ILogger<LoggingBehaviorPipeline<TRequest, TResponse>> logger) =>
        _logger = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Handling {typeof(TRequest).Name}");
        var timer = Stopwatch.StartNew();

        var response = await next();

        timer.Stop();
        var timerElapsed = timer.ElapsedMilliseconds;

        if (timerElapsed > 1000)
            _logger.LogWarning($"Long running request: {typeof(TRequest).Name} ({timerElapsed} milliseconds)");

        _logger.LogInformation($"Handled {typeof(TRequest).Name}");
        return response;
    }
}
