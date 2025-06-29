using Task_Flow_Manager.Dto.Request;
using Task_Flow_Manager.Dto.Response;

namespace Task_Flow_Manager.Services;

public interface IProjectsService
{
    Task<List<ProjectsResponse>> GetAll();
    Task<ProjectsResponse> GetById(long id);
    Task<ProjectsResponse> Create(ProjectsRequest request);
    Task<ProjectsResponse> Update(long id, ProjectsRequest request);
    Task Delete(long id);
}