
using ESPERILLA.UseCases.InputPort;
using Microsoft.Extensions.DependencyInjection;

namespace ESPERILLA.UseCases.Interactor;

public static class PatientDependencyContainer
{
    public static IServiceCollection AddPatientInteractor(this IServiceCollection services)
    {
        services.AddTransient<ICreatePatientInputPort,CreatePatientInteractor>();
        services.AddTransient<IDeletePatientInputPort,DeletePatientInteractor>();
        services.AddTransient<IUpdatePatientInputPort, UpdatePatientInteractor>();

        services.AddTransient<IGetPatientAllInputPort, GetPatientAllInteractor>();
        services.AddTransient<IGetPatientByIdInputPort,GetPatientByIdInteractor>();
        return services;
    }
}
