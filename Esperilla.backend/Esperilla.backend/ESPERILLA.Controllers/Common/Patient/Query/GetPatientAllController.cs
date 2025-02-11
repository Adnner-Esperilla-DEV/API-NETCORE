using ESPERILLA.UseCases.InputPort;
using ESPERILLA.UseCases.OutputPort;
using ESPERILLA.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ESPERILLA.Controllers;

[Route("api/patient")]
[ApiController]
public class GetPatientAllController:ControllerBase
{
    private readonly IGetPatientAllInputPort _inputPort;
    private readonly IGetPatientAllOutputPort _outputPort;

    public GetPatientAllController(
        IGetPatientAllInputPort inputPort,
        IGetPatientAllOutputPort outputPort
    )
    {
        _inputPort = inputPort;
        _outputPort = outputPort;
    }

    [HttpGet]
    public async Task<IActionResult> GetPatientAll([FromQuery] GetPatientAllDto inputDto)
    {
        await _inputPort.Handle(inputDto: inputDto);

        return ResponseHelper.GetActionResult(_outputPort);
    }
}
