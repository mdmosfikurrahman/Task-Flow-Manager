using Task_Flow_Manager.Models;

namespace Task_Flow_Manager.Repositories;

public interface IUsersRepository
{
    Task<List<Users>> FindAllAsync();
    Task<Users?> FindByIdAsync(long id);
    Task<Users> SaveAsync(Users user);
    Task DeleteByIdAsync(long id);
    Task<bool> ExistsByIdAsync(long id);
}