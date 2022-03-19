using CleanArch.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.OrdersAgg.Events
{
    public class OrderFinilized : BaseDomainEvent
    {
        public OrderFinilized(long orderId, long userId)
        {
            OrderId = orderId;
            UserId = userId;
        }

        public long OrderId { get; private set; }
        public long UserId { get; private set; }
    }
}
