namespace Claro.order_service.Application.Handlers
{
    using Claro.order_service.Domain.DTOs;
    using Dapper;
    using MediatR;
    using System.Data;

    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderReadModel>
    {
        private readonly IDbConnection _dbConnection;

        public GetOrderByIdHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<OrderReadModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var query = "SELECT Id, CustomerId, TotalAmount, Status FROM Orders WHERE Id = @OrderId";
            return await _dbConnection.QueryFirstOrDefaultAsync<OrderReadModel>(query, new { request.OrderId });
        }
    }

}
