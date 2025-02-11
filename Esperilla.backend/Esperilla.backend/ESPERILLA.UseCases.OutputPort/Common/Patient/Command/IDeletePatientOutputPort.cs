

namespace ESPERILLA.UseCases.OutputPort;

public interface IDeletePatientOutputPort : IOutputPort<bool?>
{
    Task HandleSuccess(IHandleSuccess<bool> success);
    Task HandleFailure(IHandleFailure failure);
}
