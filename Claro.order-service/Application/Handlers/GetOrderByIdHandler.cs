namespace Claro.order_service.Application.Handlers
{
    using Claro.order_service.Domain.DTOs;
    using Claro.OrderService.Application.Interfaces;
    using Dapper;
    using MediatR;
    using System.Data;

    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderReadModel>
    {
        //private readonly IDbConnection _dbConnection;
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        //public GetOrderByIdHandler(IDbConnection dbConnection)
        //{
        //    _dbConnection = dbConnection;
        //}

        public async Task<OrderReadModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);

            if (order == null)
                return null;

            return new OrderReadModel
            {
                Id = order.Id,
                OrderDate = order.CreatedAt,
                CustomerName = order.CustomerName,
                TotalAmount = order.TotalAmount,
                Status = order.Status
            };
            //var query = "SELECT Id, CustomerId, TotalAmount, Status FROM Orders WHERE Id = @OrderId";
            //return await _dbConnection.QueryFirstOrDefaultAsync<OrderReadModel>(query, new { request.OrderId });
        }
    }

}
