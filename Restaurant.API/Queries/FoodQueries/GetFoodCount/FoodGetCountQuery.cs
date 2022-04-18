using MediatR;
using Restaurant_Web_API.DTOs;

namespace Restaurant_Web_API.Queries.FoodQueries.GetFoodCount
{
    public class FoodGetCountQuery : IRequest<ResponseDto<int>>
    {
    }
}
