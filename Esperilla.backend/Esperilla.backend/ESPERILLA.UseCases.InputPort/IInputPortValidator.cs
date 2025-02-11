using ESPERILLA.UseCases.DTOs.Interface;
namespace ESPERILLA.UseCases.InputPort;

public interface IInputPortValidator<T> : IHttpStatus, IMessagesDto
{
    Task<bool> IsValid(T entityDto);
}
