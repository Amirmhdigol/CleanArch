using CleanArch.Domain.ProductsAgg;
using CleanArch.Domain.ProductsAgg.Events;
using CleanArch.Domain.Shared;
using CleanArch.Domain.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Products
{
    public class Product : BaseAggregate
    {
        private Product()
        {

        }
        public string Description { get; private set; }
        public string Title { get; private set; }
        public Money Money { get; private set; }
        public ICollection<ProductImage> Images { get; set; }
        public Product(string title, Money money, string description)
        {
            Validate(title);
            Title = title;
            Money = money;
            Images = new List<ProductImage>();
            Description = description;
            AddDomainEvent(new ProductCreated(Id,Title));
        }

        public void Edit(string title, Money money, string description)
        {
            Validate(title);
            Title = title;
            Money = money;
            Description = description;
            AddDomainEvent(new ProductEdited()
            {
                ProductId = Id,
                Title = Title,
            });
        }

        private void Validate(string title)
        {
            NullOrEmptyDomainDataException.CheckString(title,nameof(title));
        }
        public void AddImage(string imageName)
        {
            Images.Add(new ProductImage(Id, imageName));
        }
        public void RemoveImage(long id)
        {
            var image = Images.FirstOrDefault(f => f.Id == id);
            if (image == null)
                throw new NullOrEmptyDomainDataException("Image not found");
            Images.Remove(image);
        }
    }
}
