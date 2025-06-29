using Task_Flow_Manager.Dto.Response;
using Task_Flow_Manager.Services;

namespace Task_Flow_Manager.Resolvers.Users;

[ExtendObjectType(Name = "Query")]
public class UsersQuery
{
    [GraphQLName("getUsers")]
    public async Task<List<UsersResponse>> GetUsers([Service] IUsersService service)
        => await service.GetAll();

    [GraphQLName("getUserById")]
    public async Task<UsersResponse> GetUserById(long id, [Service] IUsersService service)
        => await service.GetById(id);
}