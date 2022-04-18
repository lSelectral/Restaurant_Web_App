using MediatR;
using Restaurant_Web_API.DTOs;
using Restaurant_Web_API.Models;
using Restaurant_Web_API.Repositories.FoodRepository;

namespace Restaurant_Web_API.Queries.FoodQueries.GetAggregateFoodPrice
{
    public class FoodGetAggregatePriceQueryHandler : IRequestHandler<FoodGetAggregatePriceQuery, ResponseDto<FoodAggregatePrice>>
    {
        private readonly IFoodRepository _foodRepository;

        public FoodGetAggregatePriceQueryHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<ResponseDto<FoodAggregatePrice>> Handle(FoodGetAggregatePriceQuery request, CancellationToken cancellationToken)
        {
            var response = await _foodRepository.GetAggregateFoodPriceFromIngredientId(request.IngredientId);
            return ResponseDto<FoodAggregatePrice>.Success(response, 200);
        }
    }
}
