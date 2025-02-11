
using ESPERILLA.UseCases.Input;
using ESPERILLA.UseCases.InputPort;
using ESPERILLA.UseCases.Interface;
using ESPERILLA.UseCases.OutputPort;
using ESPERILLA.Entities;
using ESPERILLA.Entities.Utility;
namespace ESPERILLA.UseCases.Interactor;

    public class UpdatePatientInteractor :IUpdatePatientInputPort
    {
    private readonly IUpdatePatientOutputPort _outputPort;
    private readonly IPatientRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInputPortValidator<UpdatePatientDto> _validator;


    public UpdatePatientInteractor(
        IUnitOfWork unitOfWork,
        IPatientRepository repository,
        IUpdatePatientOutputPort outputPort,
        IInputPortValidator<UpdatePatientDto> validator
        )
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _outputPort = outputPort;
        _validator = validator;

    }

    public async Task Handle(UpdatePatientDto inputDto)
    {
        bool IsValid = await _validator.IsValid(inputDto);
        if (!IsValid)
        {
            await _outputPort.HandleFailure(HandleFailure.Fail(
                messages: _validator.Messages,
                statusCode: _validator.HttpStatusCode));

            return;
        }

        Patient? patient = await _repository.GetPatientByIdAsync(inputDto.getPatientId());


        patient.setName(name: inputDto.Name);
        patient.setLastName(lastName: inputDto.LastName);
        patient.setBirthDate(birthDate: DateUtility.ToDateTimeUniversalUTC(inputDto.BirthDate)!.Value);
        patient.setAddress(address: inputDto.Address);
        patient.setPhone(phone: inputDto.Phone);

        await _repository.Update(patient);
        await _unitOfWork.SaveChanges();
        await _outputPort.HandleSuccess(HandleSuccess<bool>.Ok(data: true));
    }
}

