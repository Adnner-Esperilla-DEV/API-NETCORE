

using ESPERILLA.UseCases.Input;

namespace ESPERILLA.UseCases.InputPort;

public interface IUpdatePatientInputPort
{
    Task Handle(UpdatePatientDto inputDto);
}
