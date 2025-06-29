using Task_Flow_Manager.Dto.Request;
using Task_Flow_Manager.Dto.Response;
using Task_Flow_Manager.Exceptions;
using Task_Flow_Manager.Mappers;
using Task_Flow_Manager.Models;
using Task_Flow_Manager.Repositories;
using Task_Flow_Manager.Validators;

namespace Task_Flow_Manager.Services.Impl;

public class ProjectsServiceImpl(IProjectsRepository repository) : IProjectsService
{
    public async Task<List<ProjectsResponse>> GetAll()
    {
        var projects = await repository.FindAllAsync();
        if (projects.Count == 0)
            throw new NotFoundException("No projects found");

        return projects.ToResponseList<Projects, ProjectsResponse>();
    }

    public async Task<ProjectsResponse> GetById(long id)
    {
        var project = await repository.FindByIdAsync(id);
        if (project == null)
            throw new NotFoundException($"Project not found with id: {id}");

        return project.ToResponse<Projects, ProjectsResponse>();
    }

    public async Task<ProjectsResponse> Create(ProjectsRequest request)
    {
        ProjectsRequestValidator.Validate(request);
        var entity = request.ToEntity<ProjectsRequest, Projects>();
        var saved = await repository.SaveAsync(entity);
        return saved.ToResponse<Projects, ProjectsResponse>();
    }

    public async Task<ProjectsResponse> Update(long id, ProjectsRequest request)
    {
        ProjectsRequestValidator.Validate(request);
        var existing = await repository.FindByIdAsync(id);
        if (existing == null)
            throw new NotFoundException($"Project not found with id: {id}");

        request.MapToExisting(existing);
        var updated = await repository.SaveAsync(existing);
        return updated.ToResponse<Projects, ProjectsResponse>();
    }

    public async Task Delete(long id)
    {
        if (!await repository.ExistsByIdAsync(id))
            throw new NotFoundException($"Project not found with id: {id}");

        await repository.DeleteByIdAsync(id);
    }
}
