using MediatR;
using Restaurant_Web_API.DTOs;

namespace Restaurant_Web_API.Commands.Food.FoodUpdate
{
    public class FoodUpdateCommand : IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FoodType { get; set; }
        public decimal Price { get; set; }
    }
}
