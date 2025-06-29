using Task_Flow_Manager.Dto.Response;
using Task_Flow_Manager.Services;

namespace Task_Flow_Manager.Resolvers.Projects;

[ExtendObjectType(Name = "Query")]
public class ProjectsQuery
{
    [GraphQLName("getProjects")]
    public async Task<List<ProjectsResponse>> GetProjects([Service] IProjectsService service)
        => await service.GetAll();

    [GraphQLName("getProjectById")]
    public async Task<ProjectsResponse> GetProjectById(long id, [Service] IProjectsService service)
        => await service.GetById(id);
}