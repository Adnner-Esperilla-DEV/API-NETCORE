

namespace ESPERILLA.UseCases.OutputPort;

public interface IUpdatePatientOutputPort : IOutputPort<bool?>
{
    Task HandleSuccess(IHandleSuccess<bool> success);
    Task HandleFailure(IHandleFailure failure);
}
