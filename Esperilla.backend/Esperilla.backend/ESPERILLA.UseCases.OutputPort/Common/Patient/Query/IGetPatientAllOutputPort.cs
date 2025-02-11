

using ESPERILLA.UseCases.DTOs.Output;
using ESPERILLA.UseCases.Query;

namespace ESPERILLA.UseCases.OutputPort;

public interface IGetPatientAllOutputPort :IOutputPort<QueryResult<IEnumerable<PatientDto>>?>
{
    Task HandleSuccess(IHandleSuccess<QueryResult<IEnumerable<PatientDto>> > success);
    Task HandleFailure(IHandleFailure failure);
}
