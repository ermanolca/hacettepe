using Hacettepe.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hacettepe.Application.Database.Maps;

public class SettingsMap: EntityMapBase<Settings>
{
    public override void Configure(EntityTypeBuilder<Settings> builder)
    {
        base.Configure(builder);
    }
}