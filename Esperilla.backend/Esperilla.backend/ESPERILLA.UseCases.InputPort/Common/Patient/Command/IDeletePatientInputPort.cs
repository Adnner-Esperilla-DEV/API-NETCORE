

using ESPERILLA.UseCases.Input;

namespace ESPERILLA.UseCases.InputPort;

public interface IDeletePatientInputPort
{
    Task Handle(DeletePatientDto inputDto);
}
