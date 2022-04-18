using MediatR;

namespace Restaurant_Web_API.Events
{
    public class FoodCreatedEvent : INotification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
