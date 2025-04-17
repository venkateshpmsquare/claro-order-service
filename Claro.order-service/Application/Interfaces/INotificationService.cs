namespace Claro.order_service.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendOrderConfirmationEmailAsync(int orderId);
    }
}
