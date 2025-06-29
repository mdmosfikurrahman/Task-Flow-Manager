using Task_Flow_Manager.Dto.Request;
using Task_Flow_Manager.Dto.Response;
using Task_Flow_Manager.Services;

namespace Task_Flow_Manager.Resolvers.Tasks;

[ExtendObjectType(Name = "Mutation")]
public class TasksMutation
{
    [GraphQLName("createTask")]
    public async Task<TasksResponse> CreateTask(TasksRequest input,
        [Service] ITasksService service)
        => await service.Create(input);

    [GraphQLName("updateTask")]
    public async Task<TasksResponse> UpdateTask(long id, TasksRequest input,
        [Service] ITasksService service)
        => await service.Update(id, input);

    [GraphQLName("deleteTask")]
    public async Task<bool> DeleteTask(long id, [Service] ITasksService service)
    {
        await service.Delete(id);
        return true;
    }
}