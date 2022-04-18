using MediatR;
using Restaurant_Web_API.DTOs;
using Restaurant_Web_API.Repositories.FoodRepository;

namespace Restaurant_Web_API.Commands.Food.FoodUpdate
{
    public class FoodUpdateCommandHandler : IRequestHandler<FoodUpdateCommand, ResponseDto<NoContent>>
    {
        private readonly IFoodRepository _foodRepository;

        public FoodUpdateCommandHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(FoodUpdateCommand request, CancellationToken cancellationToken)
        {
            var result = await _foodRepository.UpdateFood(request);
            Console.WriteLine($"Update result is {result}");
            if (!result)
            {
                return (ResponseDto<NoContent>.Fail("Update İşlemi Başarısız", 500));
            }
            return ResponseDto<NoContent>.Success(204);
        }
    }
}
