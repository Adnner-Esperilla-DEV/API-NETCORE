

using ESPERILLA.Gateways.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ESPERILLA.Gateways.SqlServer;

public  class ConetextFactory: IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

        optionsBuilder.UseSqlServer("Server= 10.10.2.214;Database=Prueba;User=postulante;Password=8sLq!dF3p@Gz6Vm;Encrypt=False;");

        return new ApplicationContext(optionsBuilder.Options);
    }
}
