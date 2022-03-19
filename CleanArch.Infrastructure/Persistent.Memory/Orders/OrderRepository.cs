using CleanArch.Domain.OrdersAgg;
using CleanArch.Domain.OrdersAgg.Repository;
using CleanArch.Infrastructure.Persistent.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Persistent.Memory.Orders
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
            _context.Orders.Add(order);
        }

        public async Task<Order> GetById(long id)
        {
            return _context.Orders.FirstOrDefault(p => p.Id == id);
        }

        

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Order order)
        {
            _context.Update(order);
        }
    }
}
