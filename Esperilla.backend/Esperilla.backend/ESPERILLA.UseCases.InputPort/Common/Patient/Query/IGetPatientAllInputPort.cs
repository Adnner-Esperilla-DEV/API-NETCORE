

using ESPERILLA.UseCases.Input;

namespace ESPERILLA.UseCases.InputPort;

public interface IGetPatientAllInputPort
{
    Task Handle(GetPatientAllDto inputDto);
}
