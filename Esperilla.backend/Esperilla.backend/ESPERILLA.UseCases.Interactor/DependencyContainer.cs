using ESPERILLA.UseCases.InputPort;
using Microsoft.Extensions.DependencyInjection;


namespace ESPERILLA.UseCases.Interactor
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddInteractors(this IServiceCollection services)
        {
            services.AddPatientInteractor();
            return services;
        }
    }
}
