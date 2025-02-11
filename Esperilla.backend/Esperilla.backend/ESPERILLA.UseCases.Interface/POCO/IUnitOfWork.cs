

namespace ESPERILLA.UseCases.Interface;

public interface IUnitOfWork
{
    Task<int> SaveChanges();
}
