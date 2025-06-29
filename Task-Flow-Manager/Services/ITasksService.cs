using Task_Flow_Manager.Dto.Request;
using Task_Flow_Manager.Dto.Response;

namespace Task_Flow_Manager.Services;

public interface ITasksService
{
    Task<List<TasksResponse>> GetAll();
    Task<TasksResponse> GetById(long id);
    Task<TasksResponse> Create(TasksRequest request);
    Task<TasksResponse> Update(long id, TasksRequest request);
    Task Delete(long id);
}