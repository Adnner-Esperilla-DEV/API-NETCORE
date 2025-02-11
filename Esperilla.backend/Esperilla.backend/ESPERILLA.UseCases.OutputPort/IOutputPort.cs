

using ESPERILLA.UseCases.DTOs.Interface;

namespace ESPERILLA.UseCases.OutputPort;

public interface IOutputPort<T> : IHttpStatus, IMessagesDto
{
    bool IsSuccess { get; }
    public T? Data { get; set; }
}
