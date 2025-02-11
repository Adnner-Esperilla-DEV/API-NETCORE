
using ESPERILLA.UseCases.DTOs.Input;

namespace ESPERILLA.UseCases.InputPort;

public interface ICreatePatientInputPort
{
    Task Handle(CreatePatientDto inputDto);
}
