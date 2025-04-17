using MediatR;

public record PlaceOrderCommand(int CustomerId, string CustomerName,decimal TotalAmount) : IRequest<int>;
