using GrpcContracts;

namespace Task_Flow_Manager.Services.Impl;

public class CrossServiceClientImpl(ClientService.ClientServiceClient grpcClient) : ICrossServiceClient
{
    public async Task<string> GetClientName(long id)
    {
        var response = await grpcClient.GetClientByIdAsync(new ClientRequest { Id = id });
        return response.Name;
    }
}