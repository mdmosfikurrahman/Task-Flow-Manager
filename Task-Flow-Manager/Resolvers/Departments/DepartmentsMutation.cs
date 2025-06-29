using Task_Flow_Manager.Dto.Request;
using Task_Flow_Manager.Dto.Response;
using Task_Flow_Manager.Services;

namespace Task_Flow_Manager.Resolvers.Departments;

[ExtendObjectType(Name = "Mutation")]
public class DepartmentsMutation
{
    [GraphQLName("createDepartment")]
    public async Task<DepartmentsResponse> CreateDepartment(DepartmentsRequest input,
        [Service] IDepartmentsService service)
        => await service.Create(input);

    [GraphQLName("updateDepartment")]
    public async Task<DepartmentsResponse> UpdateDepartment(long id, DepartmentsRequest input,
        [Service] IDepartmentsService service)
        => await service.Update(id, input);

    [GraphQLName("deleteDepartment")]
    public async Task<bool> DeleteDepartment(long id, [Service] IDepartmentsService service)
    {
        await service.Delete(id);
        return true;
    }
}