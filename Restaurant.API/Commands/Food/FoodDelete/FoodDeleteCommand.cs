using MediatR;
using Restaurant_Web_API.DTOs;

namespace Restaurant_Web_API.Commands.Food.FoodDelete
{
    public class FoodDeleteCommand : IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }
    }
}
