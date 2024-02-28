namespace TruckTest.Application.FunctionalTests;

public interface ITestDatabase
{
    Task InitialiseAsync();

    Task DisposeAsync();

    Task ResetStateAsync();
}
