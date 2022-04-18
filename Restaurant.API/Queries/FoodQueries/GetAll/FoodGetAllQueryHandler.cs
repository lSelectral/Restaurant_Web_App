using MediatR;
using Restaurant_Web_API.DTOs;
using Restaurant_Web_API.Models;
using Restaurant_Web_API.Repositories.FoodRepository;

namespace Restaurant_Web_API.Queries.FoodQueries.GetAll
{
    public class FoodGetAllQueryHandler : IRequestHandler<FoodGetAllQuery, ResponseDto<List<FoodDto>>>
    {
        private readonly IFoodRepository _repository;

        public FoodGetAllQueryHandler(IFoodRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseDto<List<FoodDto>>> Handle(FoodGetAllQuery request, CancellationToken cancellationToken)
        {
            var foods = await _repository.GetFoods();

            var foodDtos = new List<FoodDto>();
            foods.ForEach(x => foodDtos.Add(new FoodDto(x)));
            return ResponseDto<List<FoodDto>>.Success(foodDtos, 200);
        }
    }
}
