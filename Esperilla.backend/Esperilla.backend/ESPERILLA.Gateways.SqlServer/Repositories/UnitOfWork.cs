
using ESPERILLA.UseCases.Interface;

namespace ESPERILLA.Gateways.SqlServer;

public class UnitOfWork: IUnitOfWork
{
    private ApplicationContext _context;

    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
    }

    public Task<int> SaveChanges()
    {
        return _context.SaveChangesAsync();
    }
}
