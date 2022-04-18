using MediatR;
using Restaurant_Web_API.DTOs;
using Restaurant_Web_API.Models;

namespace Restaurant_Web_API.Queries.FoodQueries.GetAll
{
    public class FoodGetAllQuery : IRequest<ResponseDto<List<FoodDto>>>
    {
    }
}
