using FoodTruckSearch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodTruckSearch.Infrastructure.Data.Configurations;

public class FoodFacilityEntityConfiguration : IEntityTypeConfiguration<FoodFacilityEntity>
{
    public void Configure(EntityTypeBuilder<FoodFacilityEntity> builder)
    {
        /*builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();*/

    }
}
