namespace Restaurant_Web_API.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
    }
}