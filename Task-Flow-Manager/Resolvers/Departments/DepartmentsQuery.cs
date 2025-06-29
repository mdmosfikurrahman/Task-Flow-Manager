using Task_Flow_Manager.Dto.Response;
using Task_Flow_Manager.Services;

namespace Task_Flow_Manager.Resolvers.Departments;

[ExtendObjectType(Name = "Query")]
public class DepartmentsQuery
{
    [GraphQLName("getDepartments")]
    public async Task<List<DepartmentsResponse>> GetDepartments([Service] IDepartmentsService service)
        => await service.GetAll();

    [GraphQLName("getDepartmentById")]
    public async Task<DepartmentsResponse> GetDepartmentById(long id, [Service] IDepartmentsService service)
        => await service.GetById(id);
}