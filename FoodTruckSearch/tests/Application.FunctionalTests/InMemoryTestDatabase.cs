using FoodTruckSearch.Domain.Entities;
using FoodTruckSearch.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace TruckTest.Application.FunctionalTests;

public class InMemoryTestDatabase : ITestDatabase
{
    // private readonly MsSqlContainer _container;
    public readonly ApplicationDbContext TrucksContext;
    public InMemoryTestDatabase()
    {
        TrucksContext = new ApplicationDbContext(
            new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("TEST").Options);
    }

    public async Task InitialiseAsync()
    {
        TrucksContext.FoodFacilityEntities.Add(new FoodFacilityEntity
        {
            locationid = 1, FoodItems = "cola", Latitude = 37.794331003246846, Longitude = -122.39581105302317, Coordinates = new Point(37.794331003246846, -122.39581105302317)
        });
        TrucksContext.FoodFacilityEntities.Add(new FoodFacilityEntity
        {
            locationid = 2, FoodItems = "Corn, Cola", Latitude = 37.74530890865633, Longitude = -122.40342005999852, Coordinates = new Point(37.74530890865633, -122.40342005999852)
        });
        TrucksContext.FoodFacilityEntities.Add(new FoodFacilityEntity
        {
            locationid = 3, FoodItems = "Burger, Salats", Latitude = 37.77551013804947, Longitude = -122.39099930600248, Coordinates = new Point(37.77551013804947, -122.39099930600248)
        });
        await TrucksContext.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        await TrucksContext.DisposeAsync();
    }

    public async Task ResetStateAsync()
    {
        // Place to Reset Db for each run.
        // No need to reset DB because of only Query. 
        await Task.CompletedTask;
    }
}
