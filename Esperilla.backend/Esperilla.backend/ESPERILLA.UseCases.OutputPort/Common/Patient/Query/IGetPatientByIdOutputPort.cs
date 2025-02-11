
using ESPERILLA.UseCases.DTOs.Output;
using ESPERILLA.UseCases.Query;

namespace ESPERILLA.UseCases.OutputPort;

public interface IGetPatientByIdOutputPort : IOutputPort<PatientDto>
{
    Task HandleSuccess(IHandleSuccess<PatientDto> success);
    Task HandleFailure(IHandleFailure failure);
}
