

using ESPERILLA.UseCases.Input;
using ESPERILLA.UseCases.InputPort;
using ESPERILLA.UseCases.OutputPort;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESPERILLA.Controllers;

[Route("api/patient")]
[ApiController]
public class UpdatePatientController :ControllerBase
{

    private readonly IUpdatePatientInputPort _inputPort;
    private readonly IUpdatePatientOutputPort _outputPort;

    public UpdatePatientController(
        IUpdatePatientInputPort inputPort,
        IUpdatePatientOutputPort outputPort
        )
    {
        _inputPort = inputPort;
        _outputPort = outputPort;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePatientDto inputDto)
    {
        inputDto.setPatientId(patientId: id);
        await _inputPort.Handle(inputDto: inputDto);

        return ResponseHelper.GetActionResult(_outputPort);

    }
}
