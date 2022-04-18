using MediatR;
using Restaurant_Web_API.DTOs;

namespace Restaurant_Web_API.Queries.FoodQueries.GetIngredientCountFromFoodId
{
    public class FoodGetIngredientCountFromFoodIdQuery : IRequest<ResponseDto<int>>
    {
        public int FoodId { get; set; }
    }
}
