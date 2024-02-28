using FoodTruckSearch.Domain.Entities;

namespace FoodTruckSearch.Application.FoodFacility.Queries.SearchTracksByFood;

public class TruckDto
{
    public string? Applicant { get; init; }
    public string? FacilityType { get; init; }
    public string? Address { get; init; }
    public string? FoodItems { get; init; }
    public int LocationId { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<FoodFacilityEntity, TruckDto>();
        }
    }
}
