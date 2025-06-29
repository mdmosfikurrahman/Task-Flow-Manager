using Task_Flow_Manager.Dto.Request;
using Task_Flow_Manager.Dto.Response;
using Task_Flow_Manager.Exceptions;
using Task_Flow_Manager.Mappers;
using Task_Flow_Manager.Models;
using Task_Flow_Manager.Repositories;
using Task_Flow_Manager.Validators;

namespace Task_Flow_Manager.Services.Impl;

public class TasksServiceImpl(ITasksRepository repository) : ITasksService
{
    public async Task<List<TasksResponse>> GetAll()
    {
        var tasks = await repository.FindAllAsync();
        if (tasks.Count == 0)
            throw new NotFoundException("No tasks found");

        return tasks.ToResponseList<Tasks, TasksResponse>();
    }

    public async Task<TasksResponse> GetById(long id)
    {
        var task = await repository.FindByIdAsync(id);
        if (task == null)
            throw new NotFoundException($"Task not found with id: {id}");

        return task.ToResponse<Tasks, TasksResponse>();
    }

    public async Task<TasksResponse> Create(TasksRequest request)
    {
        TasksRequestValidator.Validate(request);
        var entity = request.ToEntity<TasksRequest, Tasks>();
        var saved = await repository.SaveAsync(entity);
        return saved.ToResponse<Tasks, TasksResponse>();
    }

    public async Task<TasksResponse> Update(long id, TasksRequest request)
    {
        TasksRequestValidator.Validate(request);
        var existing = await repository.FindByIdAsync(id);
        if (existing == null)
            throw new NotFoundException($"Task not found with id: {id}");

        request.MapToExisting(existing);
        var updated = await repository.SaveAsync(existing);
        return updated.ToResponse<Tasks, TasksResponse>();
    }

    public async Task Delete(long id)
    {
        if (!await repository.ExistsByIdAsync(id))
            throw new NotFoundException($"Task not found with id: {id}");

        await repository.DeleteByIdAsync(id);
    }
}