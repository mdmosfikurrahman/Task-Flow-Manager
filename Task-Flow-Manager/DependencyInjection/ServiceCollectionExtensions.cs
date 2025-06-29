namespace Task_Flow_Manager.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.RegisterServices();
        services.RegisterRepositories();
        services.RegisterValidators();
        services.RegisterAutoMapperProfiles();
    }
}