using CleanArch.Domain.OrdersAgg;
using CleanArch.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Persistent.Memory
{
    public  class Context
    {
        public  List<Product> Products { get; set; }
        public  List<Order> Orders { get; set; } = new List<Order>() { new Order(222) };
    }
}
