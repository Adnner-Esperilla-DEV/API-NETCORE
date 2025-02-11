
using ESPERILLA.Entities;
using ESPERILLA.Entities.Utility;
using ESPERILLA.UseCases.DTOs.Input;
using ESPERILLA.UseCases.InputPort;
using ESPERILLA.UseCases.Interface;
using ESPERILLA.UseCases.OutputPort;

namespace ESPERILLA.UseCases.Interactor;

    public class CreatePatientInteractor : ICreatePatientInputPort
    {
        private readonly ICreatePatientOutputPort _outputPort;
        private readonly IPatientRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInputPortValidator<CreatePatientDto> _validator;

        public CreatePatientInteractor(
            IUnitOfWork unitOfWork,
            IPatientRepository repository,
            ICreatePatientOutputPort outputPort,
            IInputPortValidator<CreatePatientDto> validator
            )
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _outputPort = outputPort;
            _validator = validator;
        }

        public async Task Handle(CreatePatientDto inputDto)
        {
            bool IsValid = await _validator.IsValid(inputDto);
            if (!IsValid)
            {
                await _outputPort.HandleFailure(HandleFailure.Fail(
                    messages: _validator.Messages,
                    statusCode: _validator.HttpStatusCode));

                return;
            }
            Patient patient = new Patient(
                name:inputDto.Name,
                lastName:inputDto.LastName,
                birthDate: DateUtility.ToDateTimeUniversalUTC(inputDto.BirthDate)!.Value,
                address:inputDto.Address,
                phone:inputDto.Phone);

            await _repository.CreateAsync(patient);
            await _unitOfWork.SaveChanges();
            await _outputPort.HandleSuccess(HandleSuccess<string>.Created(data: patient.Id.ToString()));
        }
    }

