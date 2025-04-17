using MediatR;
using Claro.OrderService.Infrastructure.Persistence;
using Claro.OrderService.Domain.Entities;
using Hangfire;
using Claro.order_service.Application.Interfaces;
using StackExchange.Redis;

public class PlaceOrderHandler : IRequestHandler<PlaceOrderCommand, int>
{
    private readonly WriteDbContext _context;
    private readonly IBackgroundJobClient _backgroundJobs;
    public PlaceOrderHandler(WriteDbContext context, IBackgroundJobClient backgroundJobs)
    {
        _context = context;
        _backgroundJobs = backgroundJobs;
    }

    public async Task<int> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Claro.OrderService.Domain.Entities.Order
        {
            CustomerId = request.CustomerId,
            CustomerName = request.CustomerName,
            TotalAmount = request.TotalAmount
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        _backgroundJobs.Enqueue<INotificationService>(svc =>
            svc.SendOrderConfirmationEmailAsync(1234));

        return order.Id;
    }
}
