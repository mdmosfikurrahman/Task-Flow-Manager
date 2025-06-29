using Task_Flow_Manager.Dto.Request;
using Task_Flow_Manager.Dto.Response;
using Task_Flow_Manager.Services;

namespace Task_Flow_Manager.Resolvers.Projects;

[ExtendObjectType(Name = "Mutation")]
public class ProjectsMutation
{
    [GraphQLName("createProject")]
    public async Task<ProjectsResponse> CreateProject(ProjectsRequest input,
        [Service] IProjectsService service)
        => await service.Create(input);

    [GraphQLName("updateProject")]
    public async Task<ProjectsResponse> UpdateProject(long id, ProjectsRequest input,
        [Service] IProjectsService service)
        => await service.Update(id, input);

    [GraphQLName("deleteProject")]
    public async Task<bool> DeleteProject(long id, [Service] IProjectsService service)
    {
        await service.Delete(id);
        return true;
    }
}