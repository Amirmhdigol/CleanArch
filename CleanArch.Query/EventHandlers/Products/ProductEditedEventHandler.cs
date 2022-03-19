using CleanArch.Domain.Products.Repository;
using CleanArch.Domain.ProductsAgg.Events;
using CleanArch.Query.Models.Products;
using MediatR;

namespace CleanArch.Query.EventHandlers.Products
{
    public class ProductEditedEventHandler : INotificationHandler<ProductEdited>
    {
        private readonly IProductRepository _writeRepository;
        private readonly IProductReadRepository _readRepository;

        public ProductEditedEventHandler(IProductRepository writeRepository, IProductReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(ProductEdited notification, CancellationToken cancellationToken)
        {
            var product = await _writeRepository.GetById(notification.ProductId);
            await _readRepository.Update(new ProductReadModel()
            {
                Id = product.Id,
                CreationDate = product.CreationDate,
                Description = product.Description,
                Images = product.Images,
                Title = product.Title,
                Money = product.Money
            });
        }
    }
}
