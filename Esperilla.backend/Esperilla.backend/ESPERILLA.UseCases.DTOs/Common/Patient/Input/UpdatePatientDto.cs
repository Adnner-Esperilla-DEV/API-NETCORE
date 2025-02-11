
using ESPERILLA.UseCases.DTOs.Input;

namespace ESPERILLA.UseCases.Input;

public class UpdatePatientDto :CreatePatientDto
{
    private Guid _patientId;

    public void setPatientId(Guid patientId)
    {
        _patientId = patientId;
    }
    public Guid getPatientId() 
    { 
     return _patientId;
    }
}
