using Task_Flow_Manager.Models;

namespace Task_Flow_Manager.Repositories;

public interface IDepartmentsRepository
{
    Task<List<Departments>> FindAllAsync();
    Task<Departments?> FindByIdAsync(long id);
    Task<Departments> SaveAsync(Departments entity);
    Task DeleteByIdAsync(long id);
    Task<bool> ExistsByIdAsync(long id);
}