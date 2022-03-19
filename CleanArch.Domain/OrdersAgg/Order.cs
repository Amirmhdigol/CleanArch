using CleanArch.Domain.OrdersAgg;
using CleanArch.Domain.OrdersAgg.Events;
using CleanArch.Domain.OrdersAgg.Exceptions;
using CleanArch.Domain.OrdersAgg.Services;
using CleanArch.Domain.Shared;
using CleanArch.Domain.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.OrdersAgg
{
    public class Order : BaseAggregate
    {
        private Order()
        {

        }
        public long UserId { get; private set; }
        public long ProductId { get; private set; }
        public int TotalPrice=>Items.Sum(a=>a.Price.Value);
        public int TotalItems { get; set; }
        public bool IsFinally { get; private set; }
        public DateTime FinallizedDate { get; private set; }
        public ICollection<OrderItem> Items { get; private set; }
        public Order(long userId)
        {
            UserId = userId;
            Items = new List<OrderItem>();
        }

        public void Finallize()
        {
            IsFinally = true;
            FinallizedDate = DateTime.Now;
            AddDomainEvent(new OrderFinilized(Id,UserId));
        }
        public void AddItem(long productId, int count, int price, IOrderDomainService orderDomainService)
        {
            if (orderDomainService.IsProductNotExists(productId))
                throw new ProductNotFoundException();

            if (Items.Any(p => p.ProductId == productId))
                return;

            Items.Add(new OrderItem(Id, Money.FromTooman(price), productId, count));
            TotalItems += count;
        }
        public void RemoveItem(long productId)
        {
            var item = Items.FirstOrDefault(f => f.ProductId == productId);
            if (item == null)
                throw new InvalidDomainDataException();
            Items.Remove(item);
            TotalItems -= item.Count;
        }
    }
}