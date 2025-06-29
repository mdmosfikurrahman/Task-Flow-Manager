using Task_Flow_Manager.Dto.Response;
using Task_Flow_Manager.Services;

namespace Task_Flow_Manager.Resolvers.Tasks;

[ExtendObjectType(Name = "Query")]
public class TasksQuery
{
    [GraphQLName("getTasks")]
    public async Task<List<TasksResponse>> GetTasks([Service] ITasksService service)
        => await service.GetAll();

    [GraphQLName("getTaskById")]
    public async Task<TasksResponse> GetTaskById(long id, [Service] ITasksService service)
        => await service.GetById(id);
}