using Microsoft.AspNetCore.Mvc;
using Task_Flow_Manager.Infrastructure.Dto;
using Task_Flow_Manager.Services;

namespace Task_Flow_Manager.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/clients")]
public class ClientsController
{
    [HttpGet("client-name/{id}")]
    public async Task<RestResponse<string>> GetClientName(long id, [FromServices] ICrossServiceClient crossService)
    {
        var name = await crossService.GetClientName(id);
        return RestResponse<string>.Success(200, "Client name fetched", name);
    }


}