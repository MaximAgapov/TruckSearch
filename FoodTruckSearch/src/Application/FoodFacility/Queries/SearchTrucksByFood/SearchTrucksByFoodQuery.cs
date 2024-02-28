using FoodTruckSearch.Application.Common.Interfaces;
using FoodTruckSearch.Application.FoodFacility.Queries.SearchTracksByFood;
using NetTopologySuite.Geometries;

namespace FoodTruckSearch.Application.FoodFacility.Queries.SearchTrucksByFood;

public record SearchTrucksByFoodQuery : IRequest<TrucksVm>
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int Amount { get;set; }
    public string Food { get; set; } = string.Empty;
}

public class SearchTrucksByFoodHandler : IRequestHandler<SearchTrucksByFoodQuery, TrucksVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public SearchTrucksByFoodHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TrucksVm> Handle(SearchTrucksByFoodQuery request, CancellationToken cancellationToken)
    {
        var currentLocation = new Point(request.Latitude, request.Longitude);
        return new TrucksVm
        {
            Trucks = await _context.FoodFacilityEntities
                .Where(x => x.FoodItems != null && x.FoodItems.Contains(request.Food, StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(x => x.Coordinates!.Distance(currentLocation))
                .Take(request.Amount)
                .ProjectTo<TruckDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
        };
    }
}
