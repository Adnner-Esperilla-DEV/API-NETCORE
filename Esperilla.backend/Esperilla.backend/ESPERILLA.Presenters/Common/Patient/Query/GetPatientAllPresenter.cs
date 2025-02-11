

using ESPERILLA.UseCases.DTOs;
using ESPERILLA.UseCases.DTOs.Output;
using ESPERILLA.UseCases.OutputPort;
using ESPERILLA.UseCases.Query;
using System.Net;

namespace ESPERILLA.Presenters;

public class GetPatientAllPresenter:IGetPatientAllOutputPort
{
    public bool IsSuccess
    {
        get { return Messages is null; }
    }
    public QueryResult<IEnumerable<PatientDto>>? Data { get; set; }
    public IEnumerable<MessageDto?> Messages { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; }

    public Task HandleFailure(IHandleFailure failure)
    {
        Messages = failure.Messages;
        HttpStatusCode = failure.HttpStatusCode;
        return Task.CompletedTask;
    }

    public Task HandleSuccess(IHandleSuccess<QueryResult<IEnumerable<PatientDto>>> success)
    {
        Data = success.Data;
        HttpStatusCode = success.HttpStatusCode;
        return Task.CompletedTask;
    }
}
