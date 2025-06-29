using Task_Flow_Manager.Exceptions;

namespace Task_Flow_Manager.Utils;

public static class ValidatorUtils
{
    public static void NotEmpty(string? value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException(fieldName, $"{fieldName} cannot be null or empty.");
    }

    public static void MaxLength(string? value, int maxLength, string fieldName)
    {
        if (!string.IsNullOrEmpty(value) && value.Length > maxLength)
            throw new ValidationException(fieldName, $"{fieldName} cannot exceed {maxLength} characters.");
    }

    public static void EndDateNotBeforeStartDate(DateOnly? start, DateOnly? end, string startFieldName, string endFieldName)
    {
        if (start.HasValue && end.HasValue && end < start)
            throw new ValidationException(endFieldName, $"{endFieldName} cannot be earlier than {startFieldName}.");
    }
}