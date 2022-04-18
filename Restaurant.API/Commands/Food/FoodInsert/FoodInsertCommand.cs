using MediatR;
using Restaurant_Web_API.DTOs;

namespace Restaurant_Web_API.Commands.Food.FoodInsert
{
    public class FoodInsertCommand : IRequest<ResponseDto<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> Ingredients { get; set; }
        public int FoodType { get; set; }
        public decimal Price { get; set; }
    }
}
