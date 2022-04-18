using MediatR;
using Restaurant_Web_API.DTOs;
using Restaurant_Web_API.Models;
using Restaurant_Web_API.Repositories.FoodRepository;

namespace Restaurant_Web_API.Queries.FoodQueries.GetFoodIngredientTable
{
    public class FoodGetIngredientTableQueryHandler : IRequestHandler<FoodGetIngredientTableQuery, ResponseDto<List<FoodIngredientTable>>>
    {
        private readonly IFoodRepository _foodRepository;

        public FoodGetIngredientTableQueryHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<ResponseDto<List<FoodIngredientTable>>> Handle(FoodGetIngredientTableQuery request, CancellationToken cancellationToken)
        {
            var response = await _foodRepository.GetFoodIngredientTableFromIngredientId(request.IngredientId);
            return ResponseDto<List<FoodIngredientTable>>.Success(response, 200);
        }
    }
}
