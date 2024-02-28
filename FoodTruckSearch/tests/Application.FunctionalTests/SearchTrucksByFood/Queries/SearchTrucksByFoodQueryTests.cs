using FoodTruckSearch.Application.FoodFacility.Queries.SearchTrucksByFood;

namespace TruckTest.Application.FunctionalTests.TodoLists.Queries;

using static Testing;

public class SearchTrucksByFoodQueryTests : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnFoodTrucks()
    {
        var query = new SearchTrucksByFoodQuery
        {
            Amount = 2,
            Latitude = 37.794331003246846, 
            Longitude = -122.39581105302317,
            Food = "cola",
        };

        var result = await SendAsync(query);

        result.Trucks.Should().NotBeEmpty();
        result.Trucks.Count.Should().Be(2);
    }
    
    [TestCase("COLA", 2)]
    [TestCase("Cola", 2)]
    [TestCase("cola", 2)]
    public async Task ShouldReturnCaseInsensitive(string name, int expectedAmount)
    {
        var query = new SearchTrucksByFoodQuery
        {
            Amount = 10,
            Latitude = 37.794331003246846, 
            Longitude = -122.39581105302317,
            Food = name,
        };

        var result = await SendAsync(query);

        result.Trucks.Count.Should().Be(expectedAmount);
    }

    [TestCase(1,37.794331003246846, -122.39581105302317)]
    [TestCase(2,37.74530890865633, -122.40342005999852)]
    public async Task ShouldSortByDistance(int locationId, double latitude, double longitude)
    {
        var query = new SearchTrucksByFoodQuery
        {
            Amount = 2,
            Latitude = latitude, 
            Longitude = longitude,
            Food = "cola",
        };

        var result = await SendAsync(query);
        result.Trucks.First().LocationId.Should().Be(locationId);
    }
}
