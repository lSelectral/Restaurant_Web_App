namespace Restaurant_Web_API.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public int FoodType { get; set; }
        public decimal Price { get; set; }
    }
}