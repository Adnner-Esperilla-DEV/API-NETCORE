

using ESPERILLA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;

namespace ESPERILLA.Gateways.SqlServer;

public class PatientConfig:IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable(name: "Patient", schema: "Common");
        builder.HasKey(prop => new { prop.Id });
        builder.Property(prop => prop.Name)
            .HasMaxLength(120)
            .IsRequired(required: true);
        builder.Property(prop => prop.LastName)
            .HasMaxLength(120)
            .IsRequired(required: true);

        builder.Property(prop => prop.BirthDate)
           .IsRequired(required: true);
        builder.Property(prop => prop.Address)
           .HasMaxLength(120)
           .IsRequired(required: false);
        builder.Property(prop => prop.Phone)
           .HasMaxLength(10)
           .IsRequired(required: false);
        builder.Property(prop => prop.Created)
            .IsRequired(required: true);
        builder.Property(prop => prop.Updated)
            .IsRequired(required: true);

    }
}
