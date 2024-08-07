using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.Database.Maps;

public interface IEntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
{

}