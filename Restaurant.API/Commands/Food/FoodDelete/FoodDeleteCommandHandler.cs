using MediatR;
using Restaurant_Web_API.DTOs;
using Restaurant_Web_API.Repositories.FoodRepository;
using System.Data;

namespace Restaurant_Web_API.Commands.Food.FoodDelete
{
    public class FoodDeleteCommandHandler : IRequestHandler<FoodDeleteCommand, ResponseDto<NoContent>>
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IDbTransaction _transaction;

        public FoodDeleteCommandHandler(IFoodRepository foodRepository, IDbTransaction transaction)
        {
            _foodRepository = foodRepository;
            _transaction = transaction;
        }

        public async Task<ResponseDto<NoContent>> Handle(FoodDeleteCommand request, CancellationToken cancellationToken)
        {
            await _foodRepository.DeleteFoodWithIngredients(request);
            var result = await _foodRepository.DeleteFood(request);
            _transaction.Commit();

            if (!result)
                return ResponseDto<NoContent>.Fail("Delete command failed.", 500);
            return ResponseDto<NoContent>.Success(204);
        }
    }
}
