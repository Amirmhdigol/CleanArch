using CleanArch.Domain.OrdersAgg;
using CleanArch.Domain.OrdersAgg.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Persistent.EF.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AddDbContext _context;

        public OrderRepository(AddDbContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            _context.Add(order);
        }

        public async Task<Order> GetById(long id)
        {
            return await _context.Orders.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Order order)
        {
            _context.Update(order);
        }
    }
}
