using MediatR;

public record UpdateOrderStatusCommand(int OrderId, string Status) : IRequest<bool>;
