
using ESPERILLA.UseCases.DTOs.Input;
using ESPERILLA.UseCases.Input;
using ESPERILLA.UseCases.InputPort;
using Microsoft.Extensions.DependencyInjection;

namespace ESPERILLA.UseCases.Validator;

public static class PatientDependencyContainer
{
    public static IServiceCollection AddPatientValidator(this IServiceCollection services)
    {
        services.AddTransient<IInputPortValidator<CreatePatientDto>, CreatePatientValidator>();
        services.AddTransient<IInputPortValidator<UpdatePatientDto>, UpdatePatientValidator>();
        services.AddTransient<IInputPortValidator<DeletePatientDto>, DeletePatientValidator>();

        services.AddTransient<IInputPortValidator<GetPatientAllDto>, GetPatientAllValidator>();
        services.AddTransient<IInputPortValidator<GetPatientByIdDto>, GetPatientByIdValidator>();
        return services;
    }
}
