

using ESPERILLA.UseCases.Input;
using ESPERILLA.UseCases.InputPort;
using ESPERILLA.UseCases.OutputPort;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESPERILLA.Controllers;

[Route("api/patient")]
[ApiController]
public class DeletePatientController:ControllerBase
{
    private readonly IDeletePatientInputPort _inputPort;
    private readonly IDeletePatientOutputPort _outputPort;

    public DeletePatientController(
        IDeletePatientInputPort inputPort,
        IDeletePatientOutputPort outputPort
        )
    {
        _inputPort = inputPort;
        _outputPort = outputPort;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {

        DeletePatientDto inputDto = new()
        {
            PatientId = id
        };
        await _inputPort.Handle(inputDto: inputDto);

        return ResponseHelper.GetActionResult(_outputPort);

    }
}
