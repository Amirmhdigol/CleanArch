using CleanArch.Domain.Products.Repository;
using CleanArch.Domain.ProductsAgg.Events;
using CleanArch.Query.Models.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.EventHandlers.Products
{
    public class ProductCreatedEventHandler : INotificationHandler<ProductCreated>
    {
        private readonly IProductRepository _writeRepository;
        private readonly IProductReadRepository _readRepository;

        public ProductCreatedEventHandler(IProductRepository writeRepository, IProductReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(ProductCreated notification, CancellationToken cancellationToken)
        {
            var product = await _writeRepository.GetById(notification.Id);
            await _readRepository.Insert(new ProductReadModel()
            {
                Id = notification.Id,
                CreationDate = product.CreationDate,
                Description = product.Description,
                Images = null,
                Title = product.Title,
                Money = product.Money
            });
        }
    }
}
