using Task_Flow_Manager.Dto.Request;
using Task_Flow_Manager.Utils;

namespace Task_Flow_Manager.Validators;

public static class TasksRequestValidator
{
    public static void Validate(TasksRequest request)
    {
        ValidatorUtils.NotEmpty(request.Title, nameof(request.Title));
        ValidatorUtils.MaxLength(request.Title, 100, nameof(request.Title));

        if (!string.IsNullOrWhiteSpace(request.Status))
            ValidatorUtils.MaxLength(request.Status, 50, nameof(request.Status));
    }
}