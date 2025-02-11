

using ESPERILLA.Presenters.Common.Patient.Query;
using ESPERILLA.UseCases.OutputPort;
using Microsoft.Extensions.DependencyInjection;

namespace ESPERILLA.Presenters;

public static class PatientDependencyContainer
{
    public static IServiceCollection AddPatientPresenters(this IServiceCollection services)
    {
        services.AddScoped<ICreatePatientOutputPort, CreatePatientPresenter>();
        services.AddScoped<IDeletePatientOutputPort, DeletePatientPresenter>();
        services.AddScoped<IUpdatePatientOutputPort, UpdatePatientPresenter>();


        services.AddScoped<IGetPatientAllOutputPort, GetPatientAllPresenter>();
        services.AddScoped<IGetPatientByIdOutputPort, GetPatientByIdPresenter>();


        return services;
    }
}

