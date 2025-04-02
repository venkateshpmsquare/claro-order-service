using MediatR;
using Claro.OrderService.Infrastructure.Persistence;
using Claro.OrderService.Domain.Entities;

public class PlaceOrderHandler : IRequestHandler<PlaceOrderCommand, int>
{
    private readonly WriteDbContext _context;

    public PlaceOrderHandler(WriteDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            CustomerId = request.CustomerId,
            TotalAmount = request.TotalAmount
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order.Id;
    }
}
