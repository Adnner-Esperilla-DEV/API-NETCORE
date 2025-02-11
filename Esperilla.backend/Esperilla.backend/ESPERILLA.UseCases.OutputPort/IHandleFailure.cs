

using ESPERILLA.UseCases.DTOs;
using System.Net;

namespace ESPERILLA.UseCases.OutputPort;

public interface IHandleFailure 
{
    public IEnumerable<MessageDto> Messages { get; }
    public HttpStatusCode HttpStatusCode { get; }
}
