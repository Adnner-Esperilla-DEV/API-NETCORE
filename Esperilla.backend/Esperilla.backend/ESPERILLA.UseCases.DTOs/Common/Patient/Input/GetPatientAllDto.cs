

using ESPERILLA.UseCases.DTOs;

namespace ESPERILLA.UseCases;

public  class GetPatientAllDto:GetQueryDto
{
    public string? FilterByNameLike { get; set; }
}
