namespace Restaurant_Web_API.Models
{
    public class FoodIngredientTable
    {
        public int FoodId { get; set; }
        public int IngredientId { get; set; }
        public string FoodName { get; set; }
        public string IngredientName { get; set; }
        public decimal FoodPrice { get; set; }
    }
}
