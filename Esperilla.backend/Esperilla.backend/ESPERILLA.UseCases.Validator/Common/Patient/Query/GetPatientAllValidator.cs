

using ESPERILLA.UseCases.DTOs;
using ESPERILLA.UseCases.InputPort;
using ESPERILLA.UseCases.Interface;
using System.Net;

namespace ESPERILLA.UseCases.Validator;

public  class GetPatientAllValidator :IInputPortValidator<GetPatientAllDto>
{
    private readonly IPatientRepository _patientRepository;
    public GetPatientAllValidator(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public IEnumerable<MessageDto?> Messages { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; }

    public async Task<bool> IsValid(GetPatientAllDto inputDto)
    {
        try
        {

            var messages = new List<MessageDto>();

            messages.AddRange(
                QueryValidator.Validate(
                    queryDto: inputDto
                )
            );
            Messages = messages;
            HttpStatusCode = messages.Count == 0 ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return messages.Count == 0;
        }
        catch (Exception ex)
        {
            HttpStatusCode = HttpStatusCode.InternalServerError;
            Messages = new List<MessageDto> { new MessageDto(String.Format("Ocurrio un error en el momento de crear la cuenta: {0}", ex.Message)) };
            return false;
        }
    }
}
