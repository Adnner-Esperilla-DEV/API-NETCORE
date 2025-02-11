

using ESPERILLA.UseCases.DTOs;
using ESPERILLA.UseCases.Input;
using ESPERILLA.UseCases.InputPort;
using ESPERILLA.UseCases.Interface;
using System.Net;

namespace ESPERILLA.UseCases.Validator;

public class DeletePatientValidator : IInputPortValidator<DeletePatientDto>
{
    private readonly IPatientRepository _patientRepository;
    public DeletePatientValidator(
        IPatientRepository patientRepository
        )
    {
        _patientRepository = patientRepository;
    }

    public IEnumerable<MessageDto?> Messages { get; set; } = [];
    public HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.UnprocessableEntity;

    public async Task<bool> IsValid(DeletePatientDto inputDto)
    {
        try
        {
            var patient = await _patientRepository.GetPatientByIdAsync(patientId: inputDto.PatientId);
            if (patient is null)
                Messages = Messages.Concat([ErrorUtility.CreateFromCode(errorCode: "0002")]);


            return Messages.ToList().Count == 0;
        }
        catch (Exception ex)
        {
            HttpStatusCode = HttpStatusCode.InternalServerError;
            Messages = [new MessageDto(String.Format("Ocurrio un error en el momento validar el servicio: {0}", ex.Message))];
            return false;
        }
    }
}
