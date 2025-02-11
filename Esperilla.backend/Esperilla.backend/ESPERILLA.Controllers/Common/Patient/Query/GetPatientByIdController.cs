

using ESPERILLA.UseCases.DTOs.Input;
using ESPERILLA.UseCases.Input;
using ESPERILLA.UseCases.InputPort;
using ESPERILLA.UseCases.OutputPort;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESPERILLA.Controllers;

[Route("api/patient")]
[ApiController]
public class GetPatientByIdController :ControllerBase
{

    private readonly IGetPatientByIdInputPort _inputPort;
    private readonly IGetPatientByIdOutputPort _outputPort;

    public GetPatientByIdController(
        IGetPatientByIdInputPort inputPort,
        IGetPatientByIdOutputPort outputPort
        )
    {
        _inputPort = inputPort;
        _outputPort = outputPort;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {

        GetPatientByIdDto inputDto = new()
        {
            PatientId = id
        };
        await _inputPort.Handle(inputDto: inputDto);

        return ResponseHelper.GetActionResult(_outputPort);

    }
}
