using Microsoft.Extensions.Options;
using Task_Flow_Manager.Infrastructure.Config;
using IOPath = System.IO.Path;

namespace Task_Flow_Manager.Services.Impl;

public class SchemaServiceImpl(
    IHttpClientFactory httpClientFactory,
    IOptions<SchemaSettings> settings,
    IWebHostEnvironment env) : ISchemaService
{
    public async Task<string> DownloadAndSaveSchema()
    {
        var client = httpClientFactory.CreateClient();
        var schemaUrl = $"{settings.Value.ApiHost.TrimEnd('/')}/api/v1/graphql/schema";
        client.DefaultRequestHeaders.Add("X-Internal-Request", "true");

        var response = await client.GetAsync(schemaUrl);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Failed to fetch schema from internal endpoint.");

        var schemaContent = await response.Content.ReadAsStringAsync();

        var savePath = IOPath.IsPathRooted(settings.Value.SchemaSavePath)
            ? settings.Value.SchemaSavePath
            : IOPath.Combine(env.ContentRootPath, settings.Value.SchemaSavePath);

        var dir = IOPath.GetDirectoryName(savePath);
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir!);

        if (File.Exists(savePath) && await File.ReadAllTextAsync(savePath) == schemaContent)
            return $"{savePath} (no changes)";
        await File.WriteAllTextAsync(savePath, schemaContent);
        return $"{savePath} (updated)";

    }
}