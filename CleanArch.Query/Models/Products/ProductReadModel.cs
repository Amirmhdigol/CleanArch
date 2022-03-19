using CleanArch.Domain.ProductsAgg;
using CleanArch.Domain.Shared;
using CleanArch.Query.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Models.Products
{
    public class ProductReadModel : BaseReadModel
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public Money Money { get; set; }
        public ICollection<ProductImage> Images { get; set; }
    }
}
