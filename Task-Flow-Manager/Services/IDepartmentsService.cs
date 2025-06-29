using Task_Flow_Manager.Dto.Request;
using Task_Flow_Manager.Dto.Response;

namespace Task_Flow_Manager.Services;

public interface IDepartmentsService
{
    Task<List<DepartmentsResponse>> GetAll();
    Task<DepartmentsResponse> GetById(long id);
    Task<DepartmentsResponse> Create(DepartmentsRequest dto);
    Task<DepartmentsResponse> Update(long id, DepartmentsRequest dto);
    Task Delete(long id);
}