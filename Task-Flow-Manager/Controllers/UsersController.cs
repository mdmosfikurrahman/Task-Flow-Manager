using Microsoft.AspNetCore.Mvc;
using Task_Flow_Manager.Dto.Request;
using Task_Flow_Manager.Dto.Response;
using Task_Flow_Manager.Infrastructure.Dto;
using Task_Flow_Manager.Services;

namespace Task_Flow_Manager.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/users")]
public class UsersController(IUsersService service) : ControllerBase
{
    [HttpGet]
    public async Task<RestResponse<List<UsersResponse>>> GetAll()
    {
        var result = await service.GetAll();
        return RestResponse<List<UsersResponse>>.Success(200, "Fetched", result);
    }

    [HttpGet("{id}")]
    public async Task<RestResponse<UsersResponse>> GetById(long id)
    {
        var result = await service.GetById(id);
        return RestResponse<UsersResponse>.Success(200, "Fetched", result);
    }

    [HttpPost]
    public async Task<RestResponse<UsersResponse>> Create([FromBody] UsersRequest request)
    {
        var result = await service.Create(request);
        return RestResponse<UsersResponse>.Success(201, "Created", result);
    }

    [HttpPut("{id}")]
    public async Task<RestResponse<UsersResponse>> Update(long id, [FromBody] UsersRequest request)
    {
        var result = await service.Update(id, request);
        return RestResponse<UsersResponse>.Success(200, "Updated", result);
    }

    [HttpDelete("{id}")]
    public async Task<RestResponse<string>> Delete(long id)
    {
        await service.Delete(id);
        return RestResponse<string>.Success(200, "Deleted", "Success");
    }
}