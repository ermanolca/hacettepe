using Hacettepe.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hacettepe.Application.Database.Maps;

public class UserMap: EntityMapBase<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
    }
}