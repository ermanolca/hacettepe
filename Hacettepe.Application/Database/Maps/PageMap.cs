using Hacettepe.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hacettepe.Application.Database.Maps;

public class PageMap: EntityMapBase<Page>
{
    public override void Configure(EntityTypeBuilder<Page> builder)
    {
        base.Configure(builder);
    }
}