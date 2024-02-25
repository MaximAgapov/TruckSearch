using FoodTruckSearch.Domain.Entities;

namespace FoodTruckSearch.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<FoodFacilityEntity> FoodFacilityEntities { get; }
}
