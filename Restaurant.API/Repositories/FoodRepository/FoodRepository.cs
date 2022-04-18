using Dapper;
using Restaurant_Web_API.Commands.Food.FoodDelete;
using Restaurant_Web_API.Commands.Food.FoodInsert;
using Restaurant_Web_API.Commands.Food.FoodUpdate;
using Restaurant_Web_API.Models;
using System.Data;

namespace Restaurant_Web_API.Repositories.FoodRepository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly IDbTransaction _transaction;

        public FoodRepository(IDbConnection dbConnection, IDbTransaction transaction)
        {
            _dbConnection = dbConnection;
            _transaction = transaction;
        }

        #region CRUD OPERATIONS

        public async Task<List<Food>> GetFoods()
        {
            //var query = "SELECT food_id, ingredient_id, foods, ingredients " +
            //            "FROM food_ingredients " +
            //            "INNER JOIN foods ON food_ingredients.food_id = foods.id " +
            //            "INNER JOIN ingredients ON food_ingredients.ingredient_id = ingredients.id";

            var foodQuery = "select * from foods";
            var mappingQuery = "select * from food_ingredients";
            var ingredientsQuery = "select * from ingredients";

            using (var multi = await _dbConnection.QueryMultipleAsync($"{foodQuery}; {mappingQuery}; {ingredientsQuery}"))
            {
                var foods = (await multi.ReadAsync<Food>()).ToList();
                var mapping = await multi.ReadAsync<FoodWithIngredients>();
                var ingredients = await multi.ReadAsync<Ingredient>();

                foods.ForEach(f =>
                    f.Ingredients = ingredients
                    .Where(i => mapping
                    .Where(m => m.Food_Id == f.Id)
                    .Select(x => x.Ingredient_Id)
                    .Contains(i.Id))
                    .ToList()
                );
                return foods;
            }
        }

        public async Task<int> SaveFood(FoodInsertCommand command)
        {
            var commandString = "insert into foods(name, description, foodtype, price)" +
                          "values(@name, @description, @foodtype, @price) returning id";
            return await _dbConnection.ExecuteScalarAsync<int>(commandString,
                new { name = command.Name, description = command.Description, foodtype = command.FoodType, price = command.Price }, _transaction);
        }

        public async Task<bool> SaveFoodWithIngredients(FoodInsertCommand command, int foodId)
        {
            var commandString = "insert into food_ingredients(food_id, ingredient_id) values";
            foreach (var ingredientId in command.Ingredients)
            {
                commandString += $"({foodId}, {ingredientId}),";
            }
            commandString = commandString.Remove(commandString.Length - 1);
            return await _dbConnection.ExecuteAsync(commandString,null,_transaction) > 0;
        }

        public async Task<bool> UpdateFood(FoodUpdateCommand command)
        {
            var commandString = "update foods set name=@name, description=@description, foodtype=@foodtype, price=@price where id=@id";
            var result =  await _dbConnection.ExecuteAsync(commandString, command) > 0;
            _transaction.Commit();
            return result;
        }

        public async Task<bool> DeleteFood(FoodDeleteCommand command)
        {
            var commandString = "delete from foods where id=@id";
            return await _dbConnection.ExecuteAsync(commandString, command, _transaction) > 0;
        }

        public async Task<bool> DeleteFoodWithIngredients(FoodDeleteCommand command)
        {
            var commandString = "delete from food_ingredients where food_id=@id";
            return await _dbConnection.ExecuteAsync(commandString, command,_transaction) > 0;
        }
        #endregion

        #region Functions

        public async Task<int> GetFoodCount()
        {
            var queryString = "func_get_food_count";
            return await _dbConnection.QuerySingleAsync<int>(queryString, commandType: CommandType.StoredProcedure);
        } 

        public async Task<int> GetIngredientCountFromFoodId(int foodIdInput)
        {
            var queryString = "func_get_ingredient_count_from_food_id";
            return await _dbConnection.QuerySingleAsync<int>(queryString, 
                new { foodid = foodIdInput }, 
                commandType: CommandType.StoredProcedure);
        }

        public async Task<FoodAggregatePrice> GetAggregateFoodPriceFromIngredientId(int id)
        {
            var queryString = "select sum_price sumprice, avg_price avgprice from func_food_sum_and_average_from_ingredient_id(@ingredientid)";
            return await _dbConnection.QuerySingleAsync<FoodAggregatePrice>(queryString, 
                new { ingredientid = id });
        }

        public async Task<List<FoodIngredientTable>> GetFoodIngredientTableFromIngredientId(int ingredientId)
        {
            var queryString = "select food_id FoodId," +
                "ingredient_id IngredientId," +
                "food_name FoodName," +
                "ingredient_name IngredientName," +
                "food_price FoodPrice " +
                "from func_get_food_table(@id)";
            return (await _dbConnection.QueryAsync<FoodIngredientTable>(queryString, 
                new {id = ingredientId})).ToList();
        }
        #endregion
    }
}
