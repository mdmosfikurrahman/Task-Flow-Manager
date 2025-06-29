using Task_Flow_Manager.Models;

namespace Task_Flow_Manager.Repositories;

public interface ITasksRepository
{
    Task<List<Tasks>> FindAllAsync();
    Task<Tasks?> FindByIdAsync(long id);
    Task<Tasks> SaveAsync(Tasks entity);
    Task DeleteByIdAsync(long id);
    Task<bool> ExistsByIdAsync(long id);
}