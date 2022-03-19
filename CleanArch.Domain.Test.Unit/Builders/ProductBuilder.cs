
using CleanArch.Domain.Products;
using CleanArch.Domain.ProductsAgg;
using CleanArch.Domain.Shared;
using System.Collections;
using System.Collections.Generic;

namespace CleanArch.Domain.Test.Unit.Builders
{
    public class ProductBuilder
    {
        private string _title = "Test";
        private string _Des = "DesTest";
        private Money _money = new(100000);
        private ICollection<ProductImage> _images;
        
        public ProductBuilder SetTitle(string title)
        {
            _title = title;
            return this;
        }
        public ProductBuilder SetMoney(int rialPrice)
        {
            _money = new Money(rialPrice);
            return this;
        }
        public ProductBuilder SetImage(string imageName)
        {
            _images.Add(new ProductImage(1,imageName));
            return this;
        }
        public Product Build()
        {
            return new Product(_title, _money,_Des);
        }
    }
}