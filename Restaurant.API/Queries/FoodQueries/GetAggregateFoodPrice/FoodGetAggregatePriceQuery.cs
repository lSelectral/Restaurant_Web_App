using MediatR;
using Restaurant_Web_API.DTOs;
using Restaurant_Web_API.Models;

namespace Restaurant_Web_API.Queries.FoodQueries.GetAggregateFoodPrice
{
    public class FoodGetAggregatePriceQuery : IRequest<ResponseDto<FoodAggregatePrice>>
    {
        public int IngredientId { get; set; }
    }
}
