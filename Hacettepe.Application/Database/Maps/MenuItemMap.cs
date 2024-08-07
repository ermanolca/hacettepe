using Hacettepe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hacettepe.Application.Database.Maps;

public class MenuItemMap: EntityMapBase<MenuItem>
{
    public override void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        base.Configure(builder);
        builder.HasOne(x=> x.Parent)
                .WithMany(x=> x.SubMenuItems)
                .HasForeignKey(x=> x.ParentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
    }
}