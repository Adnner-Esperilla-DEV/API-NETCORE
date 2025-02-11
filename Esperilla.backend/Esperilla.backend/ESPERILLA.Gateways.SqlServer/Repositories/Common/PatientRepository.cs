
using ESPERILLA.Entities;
using ESPERILLA.UseCases.Interface;
using ESPERILLA.UseCases.Query;
using Microsoft.EntityFrameworkCore;

namespace ESPERILLA.Gateways.SqlServer;

public class PatientRepository:IPatientRepository
{
    private ApplicationContext _context;
    public PatientRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Patient color)
    {
        await _context.AddAsync(color);
    }

    public async Task Update(Patient color)
    {
        _context.Update(color);
    }

    public async Task Delete(Patient color)
    {
        _context.Remove(color);
    }

    public async Task<Patient?> GetPatientByIdAsync(Guid id)
    {
        var color = await _context
            .Patient
            .FirstOrDefaultAsync(a => a.Id == id);
        return color;
    }

    public async Task<QueryResult<IEnumerable<Patient>>> GetPatientAllAsync(int page = 1, int pageSize = 10, QueryFilter<Patient>? filter = null)
    {
        var queryable = _context.Patient
            .AsQueryable();

        if (filter is not null) queryable = filter.Apply(queryable);

        var totalCount = await queryable.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        var results = await queryable.Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return QueryResult<IEnumerable<Patient>>.Success(results: results, totalCount: totalCount, totalPages: totalPages, pageNumber: page, pageSize: pageSize);

    }
}
