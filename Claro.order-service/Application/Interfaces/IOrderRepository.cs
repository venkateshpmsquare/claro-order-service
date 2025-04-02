using Claro.OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Claro.OrderService.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(Guid id);
        Task<List<Order>> GetAllOrdersAsync();
        Task AddOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(Guid id);
    }
}
