using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hacettepe.Application.Database.Maps;

public class NewsMap: EntityMapBase<Domain.News>
{
    public override void Configure(EntityTypeBuilder<Domain.News> builder)
    {
        base.Configure(builder);
    }
}