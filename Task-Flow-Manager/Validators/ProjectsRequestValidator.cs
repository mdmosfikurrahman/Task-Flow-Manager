using Task_Flow_Manager.Dto.Request;
using Task_Flow_Manager.Utils;

namespace Task_Flow_Manager.Validators;

public static class ProjectsRequestValidator
{
    public static void Validate(ProjectsRequest request)
    {
        ValidatorUtils.NotEmpty(request.Name, nameof(request.Name));
        ValidatorUtils.MaxLength(request.Name, 100, nameof(request.Name));

        if (request.StartDate.HasValue && request.EndDate.HasValue &&
            request.EndDate < request.StartDate)
        {
            throw new ArgumentException("EndDate cannot be earlier than StartDate");
        }
    }
}