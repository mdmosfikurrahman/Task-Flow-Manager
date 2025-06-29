using Microsoft.EntityFrameworkCore;
using Task_Flow_Manager.Data;
using Task_Flow_Manager.Models;
using Task = System.Threading.Tasks.Task;

namespace Task_Flow_Manager.Repositories.Impl;

public class DepartmentsRepositoryImpl(TaskFlowManagerDbContext db) : IDepartmentsRepository
{
    public async Task<List<Departments>> FindAllAsync()
        => await db.Department.Include(d => d.user).ToListAsync();

    public async Task<Departments?> FindByIdAsync(long id)
        => await db.Department.Include(d => d.user).FirstOrDefaultAsync(d => d.Id == id);

    public async Task<Departments> SaveAsync(Departments entity)
    {
        if (entity.Id == 0)
            await db.Department.AddAsync(entity);
        else
            db.Department.Update(entity);

        await db.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteByIdAsync(long id)
    {
        var entity = await db.Department.FindAsync(id);
        if (entity != null)
        {
            db.Department.Remove(entity);
            await db.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsByIdAsync(long id)
        => await db.Department.AnyAsync(d => d.Id == id);
}