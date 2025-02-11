
namespace ESPERILLA.UseCases.OutputPort;

public interface ICreatePatientOutputPort : IOutputPort<string?>
{
    Task HandleSuccess(IHandleSuccess<string> success);
    Task HandleFailure(IHandleFailure failure);
}
