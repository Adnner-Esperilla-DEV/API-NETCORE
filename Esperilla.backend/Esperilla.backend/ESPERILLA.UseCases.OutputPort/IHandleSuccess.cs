

using System.Net;

namespace ESPERILLA.UseCases.OutputPort;

public interface IHandleSuccess<T>
{
    public T? Data { get; }
    HttpStatusCode HttpStatusCode { get; }
}
