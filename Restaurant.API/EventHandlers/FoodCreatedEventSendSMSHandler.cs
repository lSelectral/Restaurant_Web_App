using MediatR;
using Restaurant_Web_API.Events;

namespace Restaurant_Web_API.EventHandlers
{
    public class FoodCreatedEventSendSMSHandler : INotificationHandler<FoodCreatedEvent>
    {
        private readonly ILogger<FoodCreatedEventSendSMSHandler> _logger;

        public FoodCreatedEventSendSMSHandler(ILogger<FoodCreatedEventSendSMSHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(FoodCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation
                ($"SMS Gönderildi: {notification.Id} ID ve {notification.Name} isimli yemek {notification.Price} ücreti ile oluşturuldu.");
            return Task.CompletedTask;
        }
    }
}
