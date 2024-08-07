using Hacettepe.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hacettepe.Application.Database.Maps;

public abstract class EntityMapBase<TEntity> : IEntityMap<TEntity> where TEntity : class, IEntityBase
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasQueryFilter(t => t.IsDeleted == false);
    }
}