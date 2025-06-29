using Task_Flow_Manager.Dto.Request;
using Task_Flow_Manager.Dto.Response;

namespace Task_Flow_Manager.Services;

public interface IUsersService
{
    Task<List<UsersResponse>> GetAll();
    Task<UsersResponse> GetById(long id);
    Task<UsersResponse> Create(UsersRequest request);
    Task<UsersResponse> Update(long id, UsersRequest request);
    Task Delete(long id);
}