

using ESPERILLA.Entities.Utility;
using ESPERILLA.Entities;
using ESPERILLA.UseCases.DTOs.Input;
using ESPERILLA.UseCases.DTOs.Output;
using ESPERILLA.UseCases.InputPort;
using ESPERILLA.UseCases.Interface;
using ESPERILLA.UseCases.OutputPort;

namespace ESPERILLA.UseCases.Interactor;

public class GetPatientByIdInteractor:IGetPatientByIdInputPort
{
    private readonly IGetPatientByIdOutputPort _outputPort;
    private readonly IPatientRepository _repository;
    private readonly IInputPortValidator<GetPatientByIdDto> _validator;

    public GetPatientByIdInteractor(
        IGetPatientByIdOutputPort outputPort,
        IPatientRepository repository,
        IInputPortValidator<GetPatientByIdDto> validator
        )
    {
        _outputPort = outputPort;
        _repository = repository;
        _validator = validator;
    }

    public async Task Handle(GetPatientByIdDto inputDto)
    {

        bool IsValid = await _validator.IsValid(inputDto);
        if (!IsValid)
        {
            await _outputPort.HandleFailure(HandleFailure.Fail(
                messages: _validator.Messages,
                statusCode: _validator.HttpStatusCode));

            return;
        }

        var patient = await _repository.GetPatientByIdAsync(patientId: inputDto.PatientId);

        PatientDto patientDto = new PatientDto(
            id: patient.Id,
            name: patient.Name,
            lastName: patient.LastName,
            birthDate: DateUtility.ToString(patient.BirthDate),
            address: patient.Address,
            phone: patient.Phone
            );

        await _outputPort.HandleSuccess(HandleSuccess<PatientDto>.Ok(data: patientDto));
    }
}
