

using ESPERILLA.UseCases.DTOs.Input;

namespace ESPERILLA.UseCases.InputPort;

public interface IGetPatientByIdInputPort
{
    Task Handle(GetPatientByIdDto inputDto);
}
