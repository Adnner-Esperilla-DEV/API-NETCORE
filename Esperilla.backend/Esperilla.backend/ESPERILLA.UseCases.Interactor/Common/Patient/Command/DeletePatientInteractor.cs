
using ESPERILLA.UseCases.Input;
using ESPERILLA.UseCases.InputPort;
using ESPERILLA.UseCases.Interface;
using ESPERILLA.UseCases.OutputPort;

namespace ESPERILLA.UseCases.Interactor;

public class DeletePatientInteractor :IDeletePatientInputPort
{
    private readonly IDeletePatientOutputPort _outputPort;
    private readonly IPatientRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInputPortValidator<DeletePatientDto> _validator;

    public DeletePatientInteractor(
        IUnitOfWork unitOfWork,
        IPatientRepository repository,
        IDeletePatientOutputPort outputPort,
        IInputPortValidator<DeletePatientDto> validator
        )
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _outputPort = outputPort;
        _validator = validator;
    }

    public async Task Handle(DeletePatientDto inputDto)
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

        await _repository.Delete(patient!);
        await _unitOfWork.SaveChanges();
        await _outputPort.HandleSuccess(HandleSuccess<bool>.Ok(data: true));
    }
}
