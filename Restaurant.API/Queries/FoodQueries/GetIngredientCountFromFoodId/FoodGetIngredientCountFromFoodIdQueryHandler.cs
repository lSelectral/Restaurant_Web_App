using MediatR;
using Restaurant_Web_API.DTOs;
using Restaurant_Web_API.Repositories.FoodRepository;

namespace Restaurant_Web_API.Queries.FoodQueries.GetIngredientCountFromFoodId
{
    public class FoodGetIngredientCountFromFoodIdQueryHandler : IRequestHandler<FoodGetIngredientCountFromFoodIdQuery, ResponseDto<int>>
    {
        private readonly IFoodRepository _foodRepository;

        public FoodGetIngredientCountFromFoodIdQueryHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<ResponseDto<int>> Handle(FoodGetIngredientCountFromFoodIdQuery request, CancellationToken cancellationToken)
        {
            var ingredientCount = await _foodRepository.GetIngredientCountFromFoodId(request.FoodId);
            return ResponseDto<int>.Success(ingredientCount, 200);
        }
    }
}
