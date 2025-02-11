using Microsoft.Extensions.DependencyInjection;

namespace ESPERILLA.Presenters;

public static class DependencyContainer
{
    public static IServiceCollection AddPresenters(this IServiceCollection services)
    {

        services.AddPatientPresenters();

        return services;
    }
}
