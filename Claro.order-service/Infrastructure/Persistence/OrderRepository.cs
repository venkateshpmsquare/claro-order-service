using Claro.OrderService.Application.Interfaces;
using Claro.OrderService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Claro.OrderService.Infrastructure.Persistence
{
    public class OrderRepository : IOrderRepository
    {
        private readonly WriteDbContext _context;

        public OrderRepository(WriteDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderByIdAsync(Guid id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}
