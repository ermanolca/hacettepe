using Hacettepe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hacettepe.Application.Database;

internal class DoctorConfiguration: IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> modelBuilder)
    {
    }
    
}