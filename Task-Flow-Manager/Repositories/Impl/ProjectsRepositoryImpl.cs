using Microsoft.EntityFrameworkCore;
using Task_Flow_Manager.Data;
using Task_Flow_Manager.Models;

namespace Task_Flow_Manager.Repositories.Impl;

public class ProjectsRepositoryImpl(TaskFlowManagerDbContext db) : IProjectsRepository
{
    public async Task<List<Projects>> FindAllAsync()
        => await db.Project.ToListAsync();

    public async Task<Projects?> FindByIdAsync(long id)
        => await db.Project.FirstOrDefaultAsync(p => p.Id == id);

    public async Task<Projects> SaveAsync(Projects entity)
    {
        if (entity.Id == 0)
            await db.Project.AddAsync(entity);
        else
            db.Project.Update(entity);

        await db.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteByIdAsync(long id)
    {
        var entity = await db.Project.FindAsync(id);
        if (entity != null)
        {
            db.Project.Remove(entity);
            await db.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsByIdAsync(long id)
        => await db.Project.AnyAsync(p => p.Id == id);
}