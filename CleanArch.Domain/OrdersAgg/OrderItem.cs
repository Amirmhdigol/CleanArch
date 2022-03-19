using CleanArch.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.OrdersAgg
{
    public class OrderItem : BaseEntity
    {
        private OrderItem()
        {

        }
        public OrderItem(long orderId, Money price, long productId, int count)
        {
            OrderId = orderId;
            Price = price;
            ProductId = productId;
            Count = count;
        }
        public long OrderId { get; private set; }
        public Money Price { get; private set; }
        public long ProductId { get; private set; }
        public int Count { get; private set; }
    }
}
