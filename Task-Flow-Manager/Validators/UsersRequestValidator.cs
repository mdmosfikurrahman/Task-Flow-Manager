using Task_Flow_Manager.Dto.Request;
using Task_Flow_Manager.Utils;

namespace Task_Flow_Manager.Validators;

public static class UsersRequestValidator
{
    public static void Validate(UsersRequest request)
    {
        ValidatorUtils.NotEmpty(request.Name, nameof(request.Name));
        ValidatorUtils.MaxLength(request.Name, 100, nameof(request.Name));

        ValidatorUtils.NotEmpty(request.Email, nameof(request.Email));
        ValidatorUtils.MaxLength(request.Email, 100, nameof(request.Email));
        ValidatorUtils.MustBeEmail(request.Email, nameof(request.Email));

        ValidatorUtils.NotEmpty(request.Phone, nameof(request.Phone));
        ValidatorUtils.MaxLength(request.Phone, 20, nameof(request.Phone));

        ValidatorUtils.NotEmpty(request.Position, nameof(request.Position));
        ValidatorUtils.MaxLength(request.Position, 100, nameof(request.Position));
    }
}