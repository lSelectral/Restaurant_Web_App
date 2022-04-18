using Restaurant_Web_API.Models;

namespace Restaurant_Web_API.DTOs
{
    public class FoodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string FoodType { get; set; }
        public decimal Price { get; set; }

        public FoodDto(Food food)
        {
            Id = food.Id;
            Name = food.Name;
            Description = food.Description;
            Price = food.Price;
            Ingredients = food.Ingredients;
            FoodType = ((FoodTypes)food.FoodType).ToString();
        }
    }
}
