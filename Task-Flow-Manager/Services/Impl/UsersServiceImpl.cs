using Task_Flow_Manager.Dto.Request;
using Task_Flow_Manager.Dto.Response;
using Task_Flow_Manager.Exceptions;
using Task_Flow_Manager.Mappers;
using Task_Flow_Manager.Models;
using Task_Flow_Manager.Repositories;
using Task_Flow_Manager.Validators;

namespace Task_Flow_Manager.Services.Impl;

public class UsersServiceImpl(IUsersRepository repository, IDepartmentsRepository departmentsRepository) : IUsersService
{
    public async Task<List<UsersResponse>> GetAll()
    {
        var users = await repository.FindAllAsync();
        if (users.Count == 0)
            throw new NotFoundException("No users found");

        return users.ToResponseList<Users, UsersResponse>();
    }

    public async Task<UsersResponse> GetById(long id)
    {
        var user = await repository.FindByIdAsync(id);
        if (user == null)
            throw new NotFoundException($"User not found with id: {id}");

        return user.ToResponse<Users, UsersResponse>();
    }

    public async Task<UsersResponse> Create(UsersRequest request)
    {
        UsersRequestValidator.Validate(request);

        var department = await departmentsRepository.FindByIdAsync(request.DepartmentId);
        if (department == null)
            throw new NotFoundException($"Department not found with id: {request.DepartmentId}");

        var user = request.ToEntity<UsersRequest, Users>();
    
        user.DepartmentId = department.Id;
        user.Department = department;

        var savedUser = await repository.SaveAsync(user);
        return savedUser.ToResponse<Users, UsersResponse>();
    }


    public async Task<UsersResponse> Update(long id, UsersRequest request)
    {
        UsersRequestValidator.Validate(request);

        var existing = await repository.FindByIdAsync(id);
        if (existing == null)
            throw new NotFoundException($"User not found with id: {id}");

        var department = await departmentsRepository.FindByIdAsync(request.DepartmentId);
        if (department == null)
            throw new NotFoundException($"Department not found with id: {request.DepartmentId}");

        request.MapToExisting(existing);

        existing.DepartmentId = department.Id;
        existing.Department = department;

        var updated = await repository.SaveAsync(existing);
        return updated.ToResponse<Users, UsersResponse>();
    }

    public async Task Delete(long id)
    {
        if (!await repository.ExistsByIdAsync(id))
            throw new NotFoundException($"User not found with id: {id}");

        await repository.DeleteByIdAsync(id);
    }
}