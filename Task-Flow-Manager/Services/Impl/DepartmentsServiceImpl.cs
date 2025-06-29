using Task_Flow_Manager.Dto.Request;
using Task_Flow_Manager.Dto.Response;
using Task_Flow_Manager.Exceptions;
using Task_Flow_Manager.Mappers;
using Task_Flow_Manager.Models;
using Task_Flow_Manager.Repositories;

namespace Task_Flow_Manager.Services.Impl;

public class DepartmentsServiceImpl(IDepartmentsRepository repository) : IDepartmentsService
{
    public async Task<List<DepartmentsResponse>> GetAll()
    {
        var departments = await repository.FindAllAsync();
        if (!departments.Any())
            throw new NotFoundException("No departments found");

        return departments.ToResponseList<Departments, DepartmentsResponse>();
    }

    public async Task<DepartmentsResponse> GetById(long id)
    {
        var department = await repository.FindByIdAsync(id);
        if (department == null)
            throw new NotFoundException($"Department not found with id: {id}");

        return department.ToResponse<Departments, DepartmentsResponse>();
    }

    public async Task<DepartmentsResponse> Create(DepartmentsRequest dto)
    {
        var entity = dto.ToEntity<DepartmentsRequest, Departments>();
        var saved = await repository.SaveAsync(entity);
        return saved.ToResponse<Departments, DepartmentsResponse>();
    }

    public async Task<DepartmentsResponse> Update(long id, DepartmentsRequest dto)
    {
        var existing = await repository.FindByIdAsync(id);
        if (existing == null)
            throw new NotFoundException($"Department not found with id: {id}");

        dto.MapToExisting(existing);
        var updated = await repository.SaveAsync(existing);
        return updated.ToResponse<Departments, DepartmentsResponse>();
    }

    public async Task Delete(long id)
    {
        if (!await repository.ExistsByIdAsync(id))
            throw new NotFoundException($"Department not found with id: {id}");

        await repository.DeleteByIdAsync(id);
    }
}