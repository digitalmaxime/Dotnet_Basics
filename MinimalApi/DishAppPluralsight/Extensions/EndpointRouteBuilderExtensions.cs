using DishAppPluralsight.EndpointHandlers;

namespace DishAppPluralsight.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static void RegisterDishesEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var dishesEndpoints = endpointRouteBuilder.MapGroup("/dishes");
        var dishWithGuidIdEndpoints = dishesEndpoints.MapGroup("/{dishId:guid}");

        dishesEndpoints.MapGet("", DishesHandlers.GetDishesAsync);
        dishWithGuidIdEndpoints.MapGet("", DishesHandlers.GetDishByIdAsync).WithName("GetDish");
        dishesEndpoints.MapGet("/{dishName}", DishesHandlers.GetDishByNameAsync);
        dishesEndpoints.MapPost("", DishesHandlers.CreateDishAsync);
        dishWithGuidIdEndpoints.MapPut("", DishesHandlers.UpdateDishByIdAsync);
        dishWithGuidIdEndpoints.MapDelete("", DishesHandlers.DeleteDishByIdAsync);
    }

    public static void RegisterIngredientsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var ingredientsEndpoints = endpointRouteBuilder.MapGroup("/dishes/{dishId:guid}/ingredients");

        ingredientsEndpoints.MapGet("", IngredientsHandlers.GetIngredientsByDishIdAsync);
    }
}