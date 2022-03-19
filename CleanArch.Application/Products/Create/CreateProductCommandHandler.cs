using CleanArch.Domain.Products;
using CleanArch.Domain.Products.Repository;
using CleanArch.Domain.ProductsAgg.Events;
using CleanArch.Domain.Shared;
using CleanArch.Domain.Shared.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IMediator _mediator;
        public CreateProductCommandHandler(IProductRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
           
            var product = new Product(request.Title,Money.FromTooman(request.Price),request.Description);
            _repository.Add(product);
            await _repository.Save();
            await _mediator.Publish(new ProductCreated(product.Id,product.Title));
            return await Unit.Task;
        }
    }
}
