using CleanArch.Domain.Products;
using CleanArch.Query.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Products
{
    public class ProductMapper
    {
        public static ProductDto MapProductToDto(Product product)
        {
            if(product == null)
                return null;

            return new ProductDto()
            {
                Id = product.Id,
                Description = product.Description,
                Money = product.Money,
                productImages = product.Images.ToList(),
                Title = product.Title,
            };
        }
    }
}
