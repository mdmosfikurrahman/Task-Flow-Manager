using Task_Flow_Manager.Exceptions;

namespace Task_Flow_Manager.Utils;

public static class ValidatorUtils
{
    public static void NotEmpty(string? value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException($"{fieldName} cannot be null or empty.", fieldName);
    }

    public static void MaxLength(string? value, int maxLength, string fieldName)
    {
        if (!string.IsNullOrEmpty(value) && value.Length > maxLength)
            throw new ValidationException($"{fieldName} cannot exceed {maxLength} characters.", fieldName);
    }
}