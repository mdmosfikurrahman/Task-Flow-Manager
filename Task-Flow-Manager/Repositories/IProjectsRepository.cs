using Task_Flow_Manager.Models;

namespace Task_Flow_Manager.Repositories;

public interface IProjectsRepository
{
    Task<List<Projects>> FindAllAsync();
    Task<Projects?> FindByIdAsync(long id);
    Task<Projects> SaveAsync(Projects entity);
    Task DeleteByIdAsync(long id);
    Task<bool> ExistsByIdAsync(long id);
}