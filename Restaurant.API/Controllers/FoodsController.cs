using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Web_API.Commands.Food.FoodDelete;
using Restaurant_Web_API.Commands.Food.FoodInsert;
using Restaurant_Web_API.Commands.Food.FoodUpdate;
using Restaurant_Web_API.Queries.FoodQueries.GetAggregateFoodPrice;
using Restaurant_Web_API.Queries.FoodQueries.GetAll;
using Restaurant_Web_API.Queries.FoodQueries.GetFoodCount;
using Restaurant_Web_API.Queries.FoodQueries.GetFoodIngredientTable;
using Restaurant_Web_API.Queries.FoodQueries.GetIngredientCountFromFoodId;

namespace Restaurant_Web_API.Controllers
{
    public class FoodsController : CustomControllerBase
    {
        private readonly IMediator _mediator;

        public FoodsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new FoodGetAllQuery());

            return CreateActionResult(response);
        }

        [HttpGet("functions/[action]")]
        public async Task<IActionResult> GetFoodCount()
        {
            var response = await _mediator.Send(new FoodGetCountQuery());
            return CreateActionResult(response);
        }

        [HttpGet("functions/[action]/{foodId}")]
        public async Task<IActionResult> GetIngredientCountFromFoodId(int foodId)
        {
            var response = await _mediator.Send(new FoodGetIngredientCountFromFoodIdQuery() { FoodId = foodId });
            return CreateActionResult(response);
        }

        [HttpGet("functions/[action]/{ingredientId}")]
        public async Task<IActionResult> GetAggregateFoodPrice(int ingredientId)
        {
            var response = await _mediator.Send(new FoodGetAggregatePriceQuery() { IngredientId = ingredientId });
            return CreateActionResult(response);
        }

        [HttpGet("functions/[action]/{ingredientId}")]
        public async Task<IActionResult> GetFoodIngredientTable(int ingredientId)
        {
            var response = await _mediator.Send(new FoodGetIngredientTableQuery() { IngredientId = ingredientId });
            return CreateActionResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveFood(FoodInsertCommand foodInsertCommand)
        {
            return CreateActionResult(await _mediator.Send(foodInsertCommand));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFood(FoodUpdateCommand foodUpdateCommand)
        {
            return CreateActionResult(await _mediator.Send(foodUpdateCommand));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFood(FoodDeleteCommand foodDeleteCommand)
        {
            return CreateActionResult(await _mediator.Send(foodDeleteCommand));
        }
    }
}
