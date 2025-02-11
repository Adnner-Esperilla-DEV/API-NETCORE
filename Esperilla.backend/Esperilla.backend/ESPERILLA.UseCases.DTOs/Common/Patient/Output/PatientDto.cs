

namespace ESPERILLA.UseCases.DTOs.Output
{
    public class PatientDto
    {
        public PatientDto(Guid id, string name, string lastName, string birthDate, string? address, string? phone)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            Address = address;
            Phone = phone;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
