using CleanArch.Domain.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.OrdersAgg.Exceptions
{
    public class ProductNotFoundException : BaseDomainException
    {
        public ProductNotFoundException(): base("Product not found")
        {

        }
    }
}
