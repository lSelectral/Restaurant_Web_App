using MediatR;
using Restaurant_Web_API.DTOs;
using Restaurant_Web_API.Models;

namespace Restaurant_Web_API.Queries.FoodQueries.GetFoodIngredientTable
{
    public class FoodGetIngredientTableQuery : IRequest<ResponseDto<List<FoodIngredientTable>>>
    {
        public int IngredientId { get; set; }
    }
}
