using Restaurant_Web_API.Commands.Food.FoodDelete;
using Restaurant_Web_API.Commands.Food.FoodInsert;
using Restaurant_Web_API.Commands.Food.FoodUpdate;
using Restaurant_Web_API.Models;

namespace Restaurant_Web_API.Repositories.FoodRepository
{
    public interface IFoodRepository
    {
        Task<List<Food>> GetFoods();

        //Task<Food> GetFoodById(int id);
        //Task<List<Food>> GetFoodsWithPage(int page, int pageSize);

        Task<int> SaveFood(FoodInsertCommand command);
        Task<bool> SaveFoodWithIngredients(FoodInsertCommand command, int foodId);
        Task<bool> UpdateFood(FoodUpdateCommand command);
        Task<bool> DeleteFood(FoodDeleteCommand command);
        Task<bool> DeleteFoodWithIngredients(FoodDeleteCommand command);
        Task<int> GetFoodCount();
        Task<int> GetIngredientCountFromFoodId(int foodId);
        Task<FoodAggregatePrice> GetAggregateFoodPriceFromIngredientId(int ingredientId);
        Task<List<FoodIngredientTable>> GetFoodIngredientTableFromIngredientId(int ingredientId);
    }
}
