namespace Task_Flow_Manager.Services;

public interface ISchemaService
{
    Task<string> DownloadAndSaveSchema();
}