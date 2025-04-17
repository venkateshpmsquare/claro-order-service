using Claro.order_service.Application.Interfaces;

namespace Claro.order_service.Application.services
{
    public class NotificationService : INotificationService
    {
        public async Task SendOrderConfirmationEmailAsync(int orderId)
        {
            // Simulate sending email
            await Task.Delay(1000);
            Console.WriteLine($"✅ Email sent for Order ID: {orderId}");
        }
    }
}
