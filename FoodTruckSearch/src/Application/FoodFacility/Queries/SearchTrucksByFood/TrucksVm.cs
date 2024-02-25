namespace FoodTruckSearch.Application.FoodFacility.Queries.SearchTracksByFood;

public class TrucksVm
{
    public IReadOnlyCollection<TruckDto> Trucks { get; init; } = Array.Empty<TruckDto>();
}
