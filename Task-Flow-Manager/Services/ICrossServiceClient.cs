namespace Task_Flow_Manager.Services;

public interface ICrossServiceClient
{
    Task<string> GetClientName(long id);
}