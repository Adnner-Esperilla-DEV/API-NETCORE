
namespace ESPERILLA.UseCases.DTOs.Input;

public  class CreatePatientDto
{
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public required string BirthDate { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }

}