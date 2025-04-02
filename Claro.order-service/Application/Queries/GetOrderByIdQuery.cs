using Claro.order_service.Domain.DTOs;
using MediatR;

public record GetOrderByIdQuery(int OrderId) : IRequest<OrderReadModel>;
