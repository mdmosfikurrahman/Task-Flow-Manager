namespace Task_Flow_Manager.DependencyInjection;

public static class ValidatorRegistrationExtensions
{
    public static void RegisterValidators(this IServiceCollection services)
    {
        var assembly = typeof(ValidatorRegistrationExtensions).Assembly;

        var validatorTypes = assembly.GetTypes()
            .Where(type => type is
            {
                IsClass: true,
                IsAbstract: false,
                Namespace: "Task_Flow_Manager.Validators"
            });

        foreach (var validatorType in validatorTypes)
        {
            services.AddScoped(validatorType);
        }
    }
}