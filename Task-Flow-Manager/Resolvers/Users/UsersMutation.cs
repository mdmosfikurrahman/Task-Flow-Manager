using Task_Flow_Manager.Dto.Request;
using Task_Flow_Manager.Dto.Response;
using Task_Flow_Manager.Services;

namespace Task_Flow_Manager.Resolvers.Users;

[ExtendObjectType(Name = "Mutation")]
public class UsersMutation
{
    [GraphQLName("createUser")]
    public async Task<UsersResponse> CreateUser(UsersRequest input,
        [Service] IUsersService service)
        => await service.Create(input);

    [GraphQLName("updateUser")]
    public async Task<UsersResponse> UpdateUser(long id, UsersRequest input,
        [Service] IUsersService service)
        => await service.Update(id, input);

    [GraphQLName("deleteUser")]
    public async Task<bool> DeleteUser(long id, [Service] IUsersService service)
    {
        await service.Delete(id);
        return true;
    }
}