using CleanArch.Domain.Shared;
using CleanArch.Domain.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.ProductsAgg
{
    public class ProductImage : BaseEntity
    {
        private ProductImage()
        {

        }
        public ProductImage(long productId,string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, "imageName");

            ProductId = productId;
            ImageName = imageName;
        }

        public long ProductId { get;private set; }
        public string ImageName { get; private set; }
    }
}