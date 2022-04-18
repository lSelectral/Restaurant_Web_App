using MediatR;
using Restaurant_Web_API.DTOs;
using Restaurant_Web_API.Events;
using Restaurant_Web_API.Repositories.FoodRepository;
using System.Data;

namespace Restaurant_Web_API.Commands.Food.FoodInsert
{
    public class FoodInsertCommandHandler : IRequestHandler<FoodInsertCommand, ResponseDto<int>>
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IDbTransaction _transaction;
        private readonly IMediator _mediator;

        public FoodInsertCommandHandler(IFoodRepository productRepository, IDbTransaction transaction, IMediator mediator)
        {
            _foodRepository = productRepository;
            _transaction = transaction;
            _mediator = mediator;
        }

        public async Task<ResponseDto<int>> Handle(FoodInsertCommand request, CancellationToken cancellationToken)
        {
            var id = await _foodRepository.SaveFood(request);
            await _foodRepository.SaveFoodWithIngredients(request, id);
            _transaction.Commit();
            await _mediator.Publish(new FoodCreatedEvent() { Id = id, Name = request.Name, Price = request.Price });
            return ResponseDto<int>.Success(id, 201);
        }
    }
}
