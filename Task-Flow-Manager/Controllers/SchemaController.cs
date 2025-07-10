using Microsoft.AspNetCore.Mvc;
using Task_Flow_Manager.Services;

namespace Task_Flow_Manager.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/schema")]
public class SchemaController(ISchemaService service) : ControllerBase
{
    [HttpGet("download")]
    public async Task<IActionResult> DownloadSchema()
    {
        var path = await service.DownloadAndSaveSchema();
        return Ok(new
        {
            message = "Schema downloaded successfully",
            savedPath = path
        });
    }
}