using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domain.OrdersAgg;

namespace CleanArch.Domain.OrdersAgg.Repository
{
    public interface IOrderRepository
    {
        Task<Order> GetById(long id);
        void Add(Order order);
        void Update(Order order);
        Task SaveChanges();
    }
}
