using Microsoft.EntityFrameworkCore;
using Task_Flow_Manager.Data;
using Task_Flow_Manager.Models;

namespace Task_Flow_Manager.Repositories.Impl;

public class TasksRepositoryImpl(TaskFlowManagerDbContext db) : ITasksRepository
{
    public async Task<List<Tasks>> FindAllAsync()
        => await db.Task
            .Include(t => t.AssignedTo)
            .ThenInclude(u => u.Department)
            .Include(t => t.Project)
            .ToListAsync();

    public async Task<Tasks?> FindByIdAsync(long id)
        => await db.Task
            .Include(t => t.AssignedTo)
            .ThenInclude(u => u.Department)
            .Include(t => t.Project)
            .FirstOrDefaultAsync(t => t.Id == id);


    public async Task<Tasks> SaveAsync(Tasks entity)
    {
        if (entity.Id == 0)
            await db.Task.AddAsync(entity);
        else
            db.Task.Update(entity);

        await db.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteByIdAsync(long id)
    {
        var entity = await db.Task.FindAsync(id);
        if (entity != null)
        {
            db.Task.Remove(entity);
            await db.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsByIdAsync(long id)
        => await db.Task.AnyAsync(t => t.Id == id);
}