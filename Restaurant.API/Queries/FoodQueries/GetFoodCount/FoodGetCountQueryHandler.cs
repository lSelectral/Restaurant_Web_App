using MediatR;
using Restaurant_Web_API.DTOs;
using Restaurant_Web_API.Repositories.FoodRepository;

namespace Restaurant_Web_API.Queries.FoodQueries.GetFoodCount
{
    public class FoodGetCountQueryHandler : IRequestHandler<FoodGetCountQuery, ResponseDto<int>>
    {
        private readonly IFoodRepository _foodRepository;

        public FoodGetCountQueryHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<ResponseDto<int>> Handle(FoodGetCountQuery request, CancellationToken cancellationToken)
        {
            var foodCount = await _foodRepository.GetFoodCount();

            return ResponseDto<int>.Success(foodCount, 200);
        }
    }
}
