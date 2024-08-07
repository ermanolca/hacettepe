using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hacettepe.Application.Database.Maps;

public class DoctorMap: EntityMapBase<Domain.Doctor>
{
    public override void Configure(EntityTypeBuilder<Domain.Doctor> builder)
    {
        base.Configure(builder);
    }
}