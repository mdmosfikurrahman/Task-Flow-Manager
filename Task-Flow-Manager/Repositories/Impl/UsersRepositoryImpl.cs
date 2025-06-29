using Microsoft.EntityFrameworkCore;
using Task_Flow_Manager.Data;
using Task_Flow_Manager.Models;

namespace Task_Flow_Manager.Repositories.Impl;

public class UsersRepositoryImpl(TaskFlowManagerDbContext db) : IUsersRepository
{
    public async Task<List<Users>> FindAllAsync()
        => await db.User.Include(u => u.Department).ToListAsync();

    public async Task<Users?> FindByIdAsync(long id)
        => await db.User.Include(u => u.Department).FirstOrDefaultAsync(u => u.Id == id);

    public async Task<Users> SaveAsync(Users user)
    {
        if (user.Id == 0)
            await db.User.AddAsync(user);
        else
            db.User.Update(user);

        await db.SaveChangesAsync();
        return user;
    }

    public async Task DeleteByIdAsync(long id)
    {
        var entity = await db.User.FindAsync(id);
        if (entity != null)
        {
            db.User.Remove(entity);
            await db.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsByIdAsync(long id)
        => await db.User.AnyAsync(u => u.Id == id);
}