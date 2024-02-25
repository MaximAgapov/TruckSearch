using FoodTruckSearch.Application.FoodFacility.Queries.SearchTracksByFood;
using FoodTruckSearch.Application.FoodFacility.Queries.SearchTrucksByFood;
using FoodTruckSearch.Web.Infrastructure;
using MediatR;

namespace FoodTruckSearch.Web.Endpoints;

public class FoodFacility : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(SearchFoodTrucks);
        // .MapPost(CreateTodoList)
        // .MapPut(UpdateTodoList, "{id}")
        // .MapDelete(DeleteTodoList, "{id}");
    }

    public Task<TrucksVm> SearchFoodTrucks(ISender sender, SearchTrucksByFoodQuery command)
    {
        return sender.Send(command);
    }

    /*public Task<int> CreateTodoList(ISender sender, CreateTodoListCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateTodoList(ISender sender, int id, UpdateTodoListCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteTodoList(ISender sender, int id)
    {
        await sender.Send(new DeleteTodoListCommand(id));
        return Results.NoContent();
    }*/
}
