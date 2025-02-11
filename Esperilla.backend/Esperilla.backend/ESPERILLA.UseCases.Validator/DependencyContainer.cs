
using Microsoft.Extensions.DependencyInjection;


namespace ESPERILLA.UseCases.Validator;

public static class DependencyContainer
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddPatientValidator();
        return services;
    }
}
