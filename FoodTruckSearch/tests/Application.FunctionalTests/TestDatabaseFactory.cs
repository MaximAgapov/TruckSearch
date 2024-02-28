namespace TruckTest.Application.FunctionalTests;

public static class TestDatabaseFactory
{
    public static async Task<ITestDatabase> CreateAsync()
    {
        ITestDatabase database = new InMemoryTestDatabase();

        await database.InitialiseAsync();

        return database;
    }
}
