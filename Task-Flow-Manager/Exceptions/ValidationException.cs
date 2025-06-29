using Task_Flow_Manager.Infrastructure.Dto;

namespace Task_Flow_Manager.Exceptions;

public class ValidationException(List<ErrorDetails> errors) : Exception("Validation failed")
{
    public List<ErrorDetails> Errors { get; } = errors;

    public ValidationException(string field, string message)
        : this([new ErrorDetails(field, message)])
    {
    }
}