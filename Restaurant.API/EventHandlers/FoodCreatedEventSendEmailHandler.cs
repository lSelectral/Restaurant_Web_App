using MediatR;
using Restaurant_Web_API.Events;

namespace Restaurant_Web_API.EventHandlers
{
    public class FoodCreatedEventSendEmailHandler : INotificationHandler<FoodCreatedEvent>
    {
        private readonly ILogger<FoodCreatedEventSendSMSHandler> _logger;

        public FoodCreatedEventSendEmailHandler(ILogger<FoodCreatedEventSendSMSHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(FoodCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation
                ($"Email Gönderildi: {notification.Id} ID ve {notification.Name} isimli yemek {notification.Price} ücreti ile oluşturuldu.");
            return Task.CompletedTask;
        }
    }
}
