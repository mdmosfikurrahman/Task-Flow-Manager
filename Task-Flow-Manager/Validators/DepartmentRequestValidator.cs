using Task_Flow_Manager.Dto.Request;
using Task_Flow_Manager.Utils;

namespace Task_Flow_Manager.Validators;

public static class DepartmentRequestValidator
{
    public static void Validate(DepartmentsRequest request)
    {
        ValidatorUtils.NotEmpty(request.Name, nameof(request.Name));
        ValidatorUtils.MaxLength(request.Name, 50, nameof(request.Name));

        ValidatorUtils.NotEmpty(request.Code, nameof(request.Code));
        ValidatorUtils.MaxLength(request.Code, 3, nameof(request.Code));

        ValidatorUtils.NotEmpty(request.Location, nameof(request.Location));
        ValidatorUtils.MaxLength(request.Location, 3, nameof(request.Location));
    }
}