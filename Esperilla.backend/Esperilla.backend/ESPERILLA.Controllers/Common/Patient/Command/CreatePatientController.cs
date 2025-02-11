

using ESPERILLA.UseCases.DTOs.Input;
using ESPERILLA.UseCases.InputPort;
using ESPERILLA.UseCases.OutputPort;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESPERILLA.Controllers;

[Route("api/patient")]
[ApiController]
public class CreatePatientController : ControllerBase
{
    private readonly ICreatePatientInputPort _inputPort;
    private readonly ICreatePatientOutputPort _outputPort;

    public CreatePatientController(
        ICreatePatientInputPort inputPort,
        ICreatePatientOutputPort outputPort
        )
    {
        _inputPort = inputPort;
        _outputPort = outputPort;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePatientDto inputDto)
    {
        await _inputPort.Handle(inputDto: inputDto);

        return ResponseHelper.GetActionResult(_outputPort);
    }
}
