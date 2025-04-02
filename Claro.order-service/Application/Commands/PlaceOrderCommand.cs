using MediatR;

public record PlaceOrderCommand(int CustomerId, decimal TotalAmount) : IRequest<int>;
