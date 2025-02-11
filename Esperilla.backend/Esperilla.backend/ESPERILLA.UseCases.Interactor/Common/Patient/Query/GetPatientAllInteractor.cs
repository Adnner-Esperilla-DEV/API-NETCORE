

using ESPERILLA.Entities.Utility;
using ESPERILLA.UseCases.DTOs.Output;
using ESPERILLA.UseCases.Input;
using ESPERILLA.UseCases.InputPort;
using ESPERILLA.UseCases.Interface;
using ESPERILLA.UseCases.OutputPort;
using ESPERILLA.UseCases.Query;

namespace ESPERILLA.UseCases.Interactor;

public class GetPatientAllInteractor:IGetPatientAllInputPort
{
    private readonly IGetPatientAllOutputPort _outputPort;
    private readonly IPatientRepository _repository;
    private readonly IInputPortValidator<GetPatientAllDto> _validator;

    public GetPatientAllInteractor(
        IGetPatientAllOutputPort outputPort,
        IPatientRepository repository,
        IInputPortValidator<GetPatientAllDto> validator
   )
    {
        _outputPort = outputPort;
        _repository = repository;
        _validator = validator;
    }

    public async Task Handle(GetPatientAllDto inputDto)
    {

        bool IsValid = await _validator.IsValid(inputDto);
        if (!IsValid)
        {
            await _outputPort.HandleFailure(HandleFailure.Fail(
                messages: _validator.Messages,
                statusCode: _validator.HttpStatusCode));

            return;
        }

        PatientAllFilter queryFilterDto = new PatientAllFilter();
        queryFilterDto.NameLike = inputDto.FilterByNameLike;

        var patients = await _repository.GetPatientAllAsync(page: inputDto.Page, pageSize: inputDto.PageSize, filter: queryFilterDto);



        List<PatientDto> patientsDto = new List<PatientDto>();
        foreach (var patient in patients.Results)
        {
            PatientDto patientDto = new PatientDto(
                id: patient.Id,
                name: patient.Name,
                lastName: patient.LastName,
                birthDate:DateUtility.ToString(patient.BirthDate),
                address:patient.Address,
                phone:patient.Phone
                );

            patientsDto.Add(patientDto);
        }

        var resultDto = QueryResult<IEnumerable<PatientDto>>.Success(
            results: patientsDto,
            totalCount: patients.TotalCount,
            totalPages: patients.TotalPages,
            pageNumber: inputDto.Page,
            pageSize: inputDto.PageSize
            );

        await _outputPort.HandleSuccess(HandleSuccess<QueryResult<IEnumerable<PatientDto>>>.Ok(data: resultDto));

    }
}
