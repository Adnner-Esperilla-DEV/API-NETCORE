
using ESPERILLA.Entities;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace ESPERILLA.Gateways.SqlServer;

public class ApplicationContext:DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new PatientConfig());
    }
    public DbSet<Patient> Patient { get; set; }
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        UdpateChangeDatesAsync();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }


    private async Task UdpateChangeDatesAsync()
    {
        var entities = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        var dateNow = DateTime.Now.ToUniversalTime(); ;

        foreach (var item in entities)
        {
            if (item.Entity is Base entity)
            {
                if (item.State == EntityState.Added) entity.Created = dateNow;
                entity.Updated = dateNow.ToUniversalTime(); ;
            }
        }

        await Task.CompletedTask;
    }
}
