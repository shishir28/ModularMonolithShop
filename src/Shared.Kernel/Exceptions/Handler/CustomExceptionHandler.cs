using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
namespace Shared.Kernel.Exceptions.Handler;

public class CustomExceptionHandler : IExceptionHandler
{
    private readonly ILogger<CustomExceptionHandler> _logger;
    public CustomExceptionHandler(ILogger<CustomExceptionHandler> logger) => _logger = logger;
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var exceptionMessage = exception.Message;        
        var statusCode = StatusCodes.Status500InternalServerError;
        var title = exception.GetType().Name;

        if (exception is BadRequestException || exception is ValidationException)
            statusCode = StatusCodes.Status400BadRequest;


        if (exception is NotFoundException)
            statusCode = StatusCodes.Status404NotFound;

        var problemDetails = new ProblemDetails
        {
            Title = title,
            Detail = exceptionMessage,
            Status = statusCode,
            Instance = httpContext.Request.Path,
        };

        problemDetails.Extensions.Add("TraceId", httpContext.TraceIdentifier);

        if (exception is ValidationException validationException)
            problemDetails.Extensions.Add("ValidationError", validationException.Errors);

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken: cancellationToken);

        return true;
    }
}

