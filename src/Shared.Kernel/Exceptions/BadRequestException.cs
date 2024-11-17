namespace Shared.Kernel.Exceptions;
public class BadRequestException : Exception
{
    public string? Details { get; }
    public BadRequestException(string message) : base(message)
    {
    }
    public BadRequestException(string message, Exception innerException) : base(message, innerException)
    {
    }
    public BadRequestException(string message, string details) : base(message) { Details = details; }
}

