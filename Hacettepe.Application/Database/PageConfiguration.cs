using Hacettepe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hacettepe.Application.Database;

internal class PageConfiguration: IEntityTypeConfiguration<Page>
{
    public void Configure(EntityTypeBuilder<Page> modelBuilder)
    {
        /*modelBuilder.Property(e => e.Published)
            .IsRequired()
            .HasColumnType("bit(1)")
            .HasColumnName("published")
            .HasConversion(ConverterProvider.GetBoolToBitArrayConverter());*/
    }
    
}