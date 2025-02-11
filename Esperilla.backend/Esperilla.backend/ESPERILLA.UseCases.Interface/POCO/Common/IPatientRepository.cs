using ESPERILLA.Entities;
using ESPERILLA.UseCases.Query;


namespace ESPERILLA.UseCases.Interface;

public interface IPatientRepository
{
    Task CreateAsync(Patient color);
    Task Update(Patient color);
    Task Delete(Patient color);
    Task<QueryResult<IEnumerable<Patient>>> GetPatientAllAsync(int page = 1, int pageSize = 10, QueryFilter<Patient>? filter = null);
    Task<Patient?> GetPatientByIdAsync(Guid patientId);
}
