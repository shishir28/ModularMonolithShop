namespace Shared.Kernel.Exceptions;
public class NotFoundException : Exception
{
    public string? Details { get; }
    public NotFoundException(string message) : base(message)
    {
    }
    public NotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
    public NotFoundException(string message, string details) : base(message) { Details = details; }
}

