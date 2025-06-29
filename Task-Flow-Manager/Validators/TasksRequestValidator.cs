using Task_Flow_Manager.Dto.Request;
using Task_Flow_Manager.Utils;

namespace Task_Flow_Manager.Validators;

public static class TasksRequestValidator
{
    public static void Validate(TasksRequest request)
    {
        ValidatorUtils.NotEmpty(request.Title, nameof(request.Title));
        ValidatorUtils.MaxLength(request.Title, 100, nameof(request.Title));

        ValidatorUtils.NotEmpty(request.Status, nameof(request.Status));
        ValidatorUtils.MaxLength(request.Status, 50, nameof(request.Status));
        
        ValidatorUtils.NotEmpty(request.Description, nameof(request.Description));
        ValidatorUtils.MaxLength(request.Description, 500, nameof(request.Description));
        
        ValidatorUtils.NotInPast(request.DueDate, nameof(request.DueDate));

        ValidatorUtils.MustBePositive(request.AssignedToId, nameof(request.AssignedToId));
        ValidatorUtils.MustBePositive(request.ProjectId, nameof(request.ProjectId));
    }
}