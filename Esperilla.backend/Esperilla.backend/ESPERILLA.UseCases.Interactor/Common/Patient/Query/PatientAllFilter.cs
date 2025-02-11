using ESPERILLA.Entities;
using ESPERILLA.UseCases.Query;


namespace ESPERILLA.UseCases.Interactor;

public class PatientAllFilter: QueryFilter<Patient>
{
    public string? NameLike { get; set; }
    public override IQueryable<Patient> Apply(IQueryable<Patient> queryable)
    {
        if (NameLike is not null) queryable = queryable.Where(p => p.Name.Contains(NameLike));

        return queryable;
    }
}
