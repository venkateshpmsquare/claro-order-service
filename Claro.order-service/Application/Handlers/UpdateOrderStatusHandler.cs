using MediatR;
using Claro.OrderService.Infrastructure.Persistence;

public class UpdateOrderStatusHandler : IRequestHandler<UpdateOrderStatusCommand, bool>
{
    private readonly WriteDbContext _context;

    public UpdateOrderStatusHandler(WriteDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FindAsync(request.OrderId);
        if (order == null) return false;

        order.Status = request.Status;
        await _context.SaveChangesAsync();
        return true;
    }
}
